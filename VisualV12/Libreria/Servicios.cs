using System;
using System.Collections.Generic;
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
                        try
                        {
                            servicioSql.Stop();
                        }
                        catch (Exception)
                        {

                        }
                        servicioSql.Start();
                    }

                    // Esperamos 10 Seg
                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            });
        }
    }
}
