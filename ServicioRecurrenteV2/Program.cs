//using System;

using System;
using System.Diagnostics;
using ServicioRecurrenteV2.Metodos;

namespace ServicioRecurrenteV2
{
    class Program
    {
        static void Main(string[] args)
        {
            oResultado oResultado = new oResultado();

            InicioSesion inicioSesion = new InicioSesion();
            oResultado = inicioSesion.GetToken("http://local.sermatick.com:8080");
            Email.EnviarMail("http://local.sermatick.com:8080", oResultado.Resultado, "ljchuello@gmail.com", "00121001002FAC000004357");

            Console.ReadLine();
        }
    }
}
