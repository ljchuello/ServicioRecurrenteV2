//using System;

using System;
using ServicioRecurrenteV2.Metodos;

namespace ServicioRecurrenteV2
{
    class Program
    {
        static void Main(string[] args)
        {
            InicioSesion inicioSesion = new InicioSesion();
            var a = inicioSesion.GetToken("http://local.sermatick.com:8080");

            Console.ReadLine();
        }
    }
}
