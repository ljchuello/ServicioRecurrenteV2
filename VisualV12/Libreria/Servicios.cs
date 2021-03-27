using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

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

        public int Count()
        {
            try
            {
                int cantidad = Process.GetProcessesByName("VisualV12").Count();
                return cantidad;
            }
            catch (Exception)
            {
                return 100;
            }
        }

        public async Task CheckAsync(string id)
        {
            await Task.Run(() =>
            {
                try
                {
                    // Obtenemos el servicio
                    var servicioSql = new ServiceController(id);

                    // Como estas?
                    if (servicioSql.Status != ServiceControllerStatus.Running && servicioSql.Status != ServiceControllerStatus.StartPending)
                    {
                        try { servicioSql.Stop(); } catch (Exception) { }
                        servicioSql.Start();
                    }

                    // Esperamos 10 Seg
                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                }
            });
        }
    }
}
