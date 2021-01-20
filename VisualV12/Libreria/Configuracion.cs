using System;
using System.IO;
using Newtonsoft.Json;

namespace VisualV12.Libreria
{
    public class Configuracion
    {
        public string Url { set; get; } = "http://localhost/";
        public string Usuario { set; get; } = "admin@admin.com";
        public string Contrasenia { set; get; } = "123456";
        public string SqlIntancia { set; get; } = "MSSQL$SQLEXPRESS";

        public string ruta = @"C:\Sermatick\";

        public bool Guardar(Configuracion configuracion)
        {
            try
            {
                // Validamos si existe la ruta
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                // Guardamos el archivos
                File.WriteAllText("C:\\Sermatick\\v12.json", JsonConvert.SerializeObject(configuracion, Formatting.Indented));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Configuracion Leer()
        {
            Configuracion configuracion = new Configuracion();
            try
            {
                // Validamos si existe la ruta
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                // Set
                string json = string.Empty;

                // Valiudamos si existe el archivo
                if (File.Exists("C:\\Sermatick\\v12.json"))
                {
                    // Leemos
                    json = File.ReadAllText("C:\\Sermatick\\v12.json");
                }

                configuracion = JsonConvert.DeserializeObject<Configuracion>(json) ?? new Configuracion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return configuracion;
        }
    }
}
