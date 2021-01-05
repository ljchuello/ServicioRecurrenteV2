using ServicioRecurrenteV2.Metodos;

namespace ServicioRecurrenteV2
{
    class Program
    {
        static void Main(string[] args)
        {
            InicioSesion inicioSesion = new InicioSesion();
            inicioSesion.ST1_ObtenerCookies("http://local.sermatick.com:8080");
            inicioSesion.ST2_IniciarSesion();
        }
    }
}
