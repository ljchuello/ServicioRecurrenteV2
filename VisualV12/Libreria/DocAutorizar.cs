using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace VisualV12.Libreria
{
    public class DocAutorizar
    {
        public Task Autorizar(List<string> documentos, Dictionary<string, string> token, string url)
        {
            return Task.Run(() =>
            {
                List<Task> list = new List<Task>();
                try
                {
                    // Recorremos y añadimos
                    foreach (var doc in documentos)
                    {
                        list.Add(AutorizarDoc_Enviar(doc, url, token));
                    }

                    // Esperamos
                    Task.WaitAll(list.ToArray());

                    // Seteamos a 0
                    list = new List<Task>();

                    // Recorremos y añadimos
                    foreach (var doc in documentos)
                    {
                        list.Add(AutorizarDoc_Recibir(doc, url, token));
                    }

                    // Esperamos
                    Task.WaitAll(list.ToArray());
                }
                catch (Exception e)
                {
                }
            });
        }

        private Task AutorizarDoc_Enviar(string idDoc, string url, Dictionary<string, string> token)
        {
            return Task.Run(() =>
            {
                try
                {
                    RestClient restClient = new RestClient($"{url}DocumentoEmitido/Enviar");
                    restClient.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddParameter("fecha_desde", "01/01/2017");
                    request.AddParameter("fecha_hasta", "01/01/2017");
                    request.AddParameter("data_table_length", "10");
                    request.AddParameter("doc_seleccionados", idDoc);
                    foreach (var row in token)
                    {
                        request.AddParameter(row.Key, row.Value, ParameterType.Cookie);
                    }
                    IRestResponse response = restClient.Execute(request);
                }
                catch (Exception ex)
                {
                }
            });
        }

        private Task AutorizarDoc_Recibir(string idDoc, string url, Dictionary<string, string> token)
        {
            return Task.Run(() =>
            {
                try
                {
                    RestClient restClient = new RestClient($"{url}DocumentoEmitido/ActualizarEstado?id={idDoc}&fecha_desde=2017/01/01&fecha_hasta=2017/01/01");
                    restClient.Timeout = -1;
                    RestRequest restRequest = new RestRequest(Method.GET);
                    //request.AddHeader("Cookie", "ASP.NET_SessionId=0ilep40draws2bdeg3oa3xa4; __RequestVerificationToken=A8FTPiJs0dfTEkqGYUPsGNwLrzbrhUER3NYOEBk3OBAAXnO3JEot9FU3NhTcRLT6BvDFKcKTNP6OofKIXqKehjZ0XQQtdPyu0GOE-wvriqs1; .AspNet.ApplicationCookie=XBgGTDEP8DkJn8pjwKAIy7Y7nTmezs3vztVKo2RNzbG0wiSc-QDDrDwf3tZhyGytiQjAD-eUYzjb9q4DoLv7fD2ti4WeXT2JTs29wvHBn7w6YnnJ6fUKxtgLttgfKbQbb9VR3gqigXHRbbB3CcrPQIBoVp0Nmts3OaVholcCZ7-WpVSjhFfEW2yD4CY2nkRRmz_Vq8w4qQWafUu4v0fy0-PB6FPLlqH7Sb1UGfB_3etZZM3xrQj-zRq6Yu_kM_dZzJFEOzIdPAN9FL6qpYIHTvVq0aprPjZh-8Z4Hu76NbnNe0H66vvLOKL1vywl-ey0QscPRSTLaf8aIEhCWMe0ked9bNUYRaRqBDD56ulUXqr-J6SDC4ADFpNEeeLiPXpU-Tfm_5a4-2smK3z1v0YJoeNOIArGJqRZZs1qphInAKuyCaKzU78LyGvVVijnU2qqvjTL-nbljMrfkAk3aEp9OfcmYqvrCiFiqDzcwIRTY1av9Dc_85H_XXWYE9U1QHNz8GdqSugZZznjZIB2Gfci2w");
                    foreach (var row in token)
                    {
                        restRequest.AddParameter(row.Key, row.Value, ParameterType.Cookie);
                    }
                    IRestResponse response = restClient.Execute(restRequest);
                }
                catch (Exception ex)
                {
                }
            });
        }
    }
}
