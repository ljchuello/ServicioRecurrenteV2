namespace VisualV12.Libreria
{
    public class oResultado
    {
        public bool Success { set; get; } = false;
        public string Mensaje { set; get; } = string.Empty;
        public dynamic Resultado { set; get; } = null;

        public oResultado Exitoso()
        {
            oResultado oResultado = new oResultado();
            oResultado.Success = true;
            oResultado.Mensaje = string.Empty;
            return oResultado;
        }

        public oResultado Exitoso(dynamic obj)
        {
            oResultado oResultado = new oResultado();
            oResultado.Success = true;
            oResultado.Mensaje = string.Empty;
            oResultado.Resultado = obj;
            return oResultado;
        }

        public oResultado Fallido(string msj)
        {
            oResultado oResultado = new oResultado();
            oResultado.Success = false;
            oResultado.Mensaje = msj;
            return oResultado;
        }
    }
}
