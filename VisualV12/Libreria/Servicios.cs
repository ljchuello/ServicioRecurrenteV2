using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace VisualV12.Libreria
{
    public class Servicios
    {
        public bool ExisteServ(string servicio)
        {
            try
            {
                List<ServiceController> services = ServiceController.GetServices().ToList();
                int cant = services.Count(x => x.ServiceName.ToLower() == servicio.ToLower());
                return cant == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
