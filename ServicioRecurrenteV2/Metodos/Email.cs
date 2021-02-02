using System;
using System.Collections.Generic;
using RestSharp;

namespace ServicioRecurrenteV2.Metodos
{
    public class Email
    {
        public static void EnviarMail(string uri, Dictionary<string, string> token, string destinatario, string idDocumento)
        {
            try
            {
                var client = new RestClient($"{uri}/DocumentoEmitido/ReenviarCorreo");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                foreach (var row in token)
                {
                    request.AddParameter(row.Key, row.Value, ParameterType.Cookie);
                }
                request.AddParameter("application/json", $"{{\"destinatarios\":\"{destinatario}\",\"doc_id\":\"{idDocumento}\"}}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
