using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using VisualV12.Libreria;

namespace VisualV12
{
    public partial class Form1 : MetroForm
    {
        private Servicios servicios = new Servicios();
        private InicioSesion _inicioSesion = new InicioSesion();
        private Configuracion configuracion = new Configuracion();
        private OdbcSql _odbcSql = new OdbcSql();
        private Email _email = new Email();

        private bool estado = true;

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            btnEstado_Click(null, null);

            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;

            configuracion = configuracion.Leer();
            txtUrl.Text = configuracion.Url;
            txtUsuario.Text = configuracion.Usuario;
            txtContrasenia.Text = configuracion.Contrasenia;
            txtSqlServer.Text = configuracion.SqlIntancia;

            Trabajar_Sql();
            Trabajar_Autorizar();
            //Trabajar_Correo();
            Trabajar_Resumen();

            Text = "Servicio Visual V12";
            lblVersion.Text = "V2021.03.02.1";
        }

        #region Principal

        private void btnEstado_Click(object sender, EventArgs e)
        {
            if (estado)
            {
                estado = false;
                btnEstado.Text = "Click para encender";
                lblEstado.Text = "Estado: Apagado 😢";
            }
            else
            {
                if (!IsAdministrator())
                {
                    MessageBox.Show("Debe ejecutar el programa como administrador\nLa aplicación se cerrará");
                    btnCerrar_Click(null, null);
                }

                // Cantidad
                if (servicios.Count() > 1)
                {
                    MessageBox.Show("El programa se cerrará, sólo se puede tener una instancia abierta.");
                    Close();
                }

                estado = true;
                btnEstado.Text = "Click para apagar";
                lblEstado.Text = "Estado: Encendido 😁";
                txtFechaInicio.Text = $"Fecha inicio: {DateTime.Now:HH:mm - dd/MM/yyyy}";
            }
        }

        #endregion

        #region Configuracion

        bool Validar()
        {
            try
            {
                #region Campos vacios

                // validamos que haya ingresado una direccion web
                if (Cadena.Vacia(txtUrl.Text))
                {
                    MessageBox.Show("Debe ingresar la Url");
                    return false;
                }

                // Validamos que haya seleccionado un usuario
                if (Cadena.Vacia(txtUsuario.Text))
                {
                    MessageBox.Show("Debe ingresar el usuario");
                    return false;
                }

                // Validamos que haya ingresado un contraseña
                if (Cadena.Vacia(txtContrasenia.Text))
                {
                    MessageBox.Show("Debe ingresar la contraseña");
                    return false;
                }

                // Validamos que haya seleccionado algo de SQL
                if (Cadena.Vacia(txtSqlServer.Text))
                {
                    MessageBox.Show("Debe ingresar la instancia de SQL");
                    return false;
                }

                #endregion

                // Validamos el inicio de sesión
                var a = _inicioSesion.GetToken(txtUrl.Text, txtUsuario.Text, txtContrasenia.Text);
                if (a.Success == false)
                {
                    MessageBox.Show($"No se ha iniciado sesión; {a.Mensaje}");
                    return false;
                }

                // Validamos si existe el servicio
                if (servicios.ExisteServ(txtSqlServer.Text) == false)
                {
                    MessageBox.Show($"No se encuentra el servicio {txtSqlServer.Text}");
                    return false;
                }

                // Guardamos la configuración
                configuracion = new Configuracion();
                configuracion.Url = txtUrl.Text;
                configuracion.Usuario = txtUsuario.Text;
                configuracion.Contrasenia = txtContrasenia.Text;
                configuracion.SqlIntancia = txtSqlServer.Text;
                if (!configuracion.Guardar(configuracion))
                {
                    MessageBox.Show("No se ha podido guardar la configuración");
                    return false;
                }

                // Libre de pecados
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ah ocurrido un error; {ex.Message}");
                return false;
            }
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!Validar())
                {
                    return;
                }

                // Libre de pecados
                MessageBox.Show("Se ha guardado la configuración");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ah ocurrido un error; {ex.Message}");
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            configuracion = configuracion.Leer();
            txtUrl.Text = configuracion.Url;
            txtUsuario.Text = configuracion.Usuario;
            txtContrasenia.Text = configuracion.Contrasenia;
            txtSqlServer.Text = configuracion.SqlIntancia;
        }

        #endregion

        // Trabajos
        async Task Trabajar_Sql()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    if (estado)
                    {
                        await servicios.CheckAsync(txtSqlServer.Text);
                    }
                    else
                    {
                        Thread.Sleep(5000);
                    }
                }
            });
        }

        async Task Trabajar_Autorizar()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        if (estado)
                        {
                            // Obtenemos la lista
                            List<string> docs = _odbcSql.Select_Top25_NoAutorizado();

                            // hay?
                            if (docs.Count >= 1)
                            {
                                // Obtenemos el token
                                oResultado casa = _inicioSesion.GetToken(txtUrl.Text, txtUsuario.Text, txtContrasenia.Text);

                                // Hacemos la tarea
                                DocAutorizar docAutorizar = new DocAutorizar();

                                // Recorremos
                                foreach (var row in docs)
                                {
                                    await docAutorizar.Autorizar(row, casa.Resultado, txtUrl.Text);
                                }
                            }
                            else
                            {
                                // No hay documentos, esperamos
                                Thread.Sleep(5000);
                            }
                        }
                        else
                        {
                            // Estado apagado esperamos
                            Thread.Sleep(5000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Configuracion.GuardarLog(ex);
                        Thread.Sleep(5000);
                    }
                }
            });
        }

        async Task Trabajar_Correo()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        if (estado)
                        {
                            // Obtenemos la lista
                            Dictionary<string, string> docs = _odbcSql.Select_Top25_NoMail();

                            // Mails sin enviar
                            lblMailSinEnviar.Text = $"Emails sin enviar: {_odbcSql.Select_Count_NoMail()}";

                            // hay datos
                            if (docs.Count != 0)
                            {
                                // Obtenemos el token
                                oResultado casa = _inicioSesion.GetToken(txtUrl.Text, txtUsuario.Text, txtContrasenia.Text);

                                // Recorremos
                                foreach (var row in docs)
                                {
                                    // Obtenemos la empresaId
                                    int empresaId = _odbcSql.Select_empresaId(row.Key);

                                    // Cambiamos de empresa
                                    await new DocAutorizar().AutorizarDoc_CambioEmp(txtUrl.Text, casa.Resultado, empresaId);

                                    // Enviamos
                                    await _email.Enviar(txtUrl.Text, row.Key, row.Value, casa.Resultado);

                                    // Mails sin enviar
                                    lblMailSinEnviar.Text = $"Emails sin enviar: {_odbcSql.Select_Count_NoMail()}";
                                }

                                Thread.Sleep(5000);
                            }
                            else
                            {
                                // No hay nada pendiente
                                Thread.Sleep(5000);
                            }
                        }
                        else
                        {
                            // Estado apagado esperamos
                            Thread.Sleep(5000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Configuracion.GuardarLog(ex);
                        Thread.Sleep(5000);
                    }
                }
            });
        }

        async Task Trabajar_Resumen()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    try
                    {
                        var list = _odbcSql.Select_Resumen();
                        foreach (var row in list)
                        {
                            stringBuilder.AppendLine($"{row.Key}: {Convert.ToInt32(row.Value):n0}");
                        }
                        lblResumen.Text = stringBuilder.ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        Thread.Sleep(2500);
                    }
                }
            });
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
