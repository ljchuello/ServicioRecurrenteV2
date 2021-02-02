using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace VisualV12.Libreria
{
    public class Email
    {
        public Task Enviar(string url, string idDoc, string correos, Dictionary<string, string> token)
        {
            return Task.Run(() =>
            {
                try
                {
                    RestClient restClient = new RestClient($"{url}DocumentoEmitido/ReenviarCorreo");
                    restClient.Timeout = -1;
                    RestRequest restRequest = new RestRequest(Method.POST);
                    restRequest.AddHeader("Content-Type", "application/json");
                    restRequest.AddHeader("Referer", $"{url}DocumentoEmitido?fecha_desde=2017/01/01&fecha_hasta=2017/01/01");
                    restRequest.AddParameter("application/json", $"{{\"destinatarios\":\"{correos}\",\"doc_id\":\"{idDoc}\"}}", ParameterType.RequestBody); foreach (var row in token)
                    {
                        restRequest.AddParameter(row.Key, row.Value, ParameterType.Cookie);
                    }
                    IRestResponse response = restClient.Execute(restRequest);
                }
                catch (Exception e)
                {

                }
            });
        }
    }
}
