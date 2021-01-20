using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Visual;
using VisualV12.Libreria;

namespace VisualV12
{
    public partial class Form1 : MetroForm
    {
        private Servicios servicios = new Servicios();
        private InicioSesion _inicioSesion = new InicioSesion();
        private Configuracion configuracion = new Configuracion();
        private OdbcSql _odbcSql = new OdbcSql();

        public Form1()
        {
            InitializeComponent();
            configuracion = configuracion.Leer();

            txtUrl.Text = configuracion.Url;
            txtUsuario.Text = configuracion.Usuario;
            txtContrasenia.Text = configuracion.Contrasenia;
            txtSqlServer.Text = configuracion.SqlIntancia;

            var a = _odbcSql.Select_Top25_NoMail();
        }

        #region Guardar

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            try
            {
                #region Campos vacios

                // validamos que haya ingresado una direccion web
                if (Cadena.Vacia(txtUrl.Text))
                {
                    MessageBox.Show("Debe ingresar la Url");
                    return;
                }

                // Validamos que haya seleccionado un usuario
                if (Cadena.Vacia(txtUsuario.Text))
                {
                    MessageBox.Show("Debe ingresar el usuario");
                    return;
                }

                // Validamos que haya ingresado un contraseña
                if (Cadena.Vacia(txtContrasenia.Text))
                {
                    MessageBox.Show("Debe ingresar la contraseña");
                    return;
                }

                // Validamos que haya seleccionado algo de SQL
                if (Cadena.Vacia(txtSqlServer.Text))
                {
                    MessageBox.Show("Debe ingresar la instancia de SQL");
                    return;
                }

                #endregion

                // Validamos el inicio de sesión
                var a = _inicioSesion.GetToken(txtUrl.Text, txtUsuario.Text, txtContrasenia.Text);
                if (a.Success == false)
                {
                    MessageBox.Show($"No se ha iniciado sesión; {a.Mensaje}");
                    return;
                }

                // Validamos si existe el servicio
                if (servicios.ExisteServ(txtSqlServer.Text) == false)
                {
                    MessageBox.Show($"No se encuentra el servicio {txtSqlServer.Text}");
                    return;
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

        #endregion


    }
}
