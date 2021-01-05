using System.Dynamic;

namespace ServicioRecurrenteV2
{
    public class oResultado
    {
        public bool Exitoso { set; get; } = false;
        public string Mensaje { set; get; } = string.Empty;
        public dynamic Resultado { set; get; } = null;
    }
}
