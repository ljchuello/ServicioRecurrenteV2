using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualV12.Libreria
{
    public class Servicios
    {
        public bool ExisteServ(string servicio)
        {
            try
            {
                ServiceController[] services = ServiceController.GetServices();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
