using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using VisualV12.Libreria;

namespace VisualV12
{
    public partial class Form1 : MetroForm
    {
        private InicioSesion _inicioSesion = new InicioSesion();

        public Form1()
        {
            InitializeComponent();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ah ocurrido un error; {ex.Message}");
            }
        }

        #endregion


    }
}
