using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace VisualV12.Libreria
{
    public class DocAutorizar
    {
        private readonly OdbcSql _odbcSql = new OdbcSql();

        public Task Autorizar(string idDocument, Dictionary<string, string> token, string url)
        {
            return Task.Run(async () =>
            {
                // Obtenemos el empresaId
                int empresaId = _odbcSql.Select_empresaId(idDocument);

                // Cambiamos de empresaId
                await AutorizarDoc_CambioEmp(url, token, empresaId);

                // Enviamos
                await AutorizarDoc_Enviar(idDocument, url, token);

                // Recibimos
                await AutorizarDoc_Recibir(idDocument, url, token);
            });
        }

        public Task AutorizarDoc_CambioEmp(string url, Dictionary<string, string> token, int empresaId)
        {
            return Task.Run(() =>
            {
                RestClient restClient = new RestClient($"{url}EmpresaAdministracion/CambiarEmpresa?empresa_id={empresaId}");
                restClient.Timeout = 90000;
                RestRequest restRequest = new RestRequest(Method.GET);
                foreach (var row in token)
                {
                    restRequest.AddParameter(row.Key, row.Value, ParameterType.Cookie);
                }
                IRestResponse response = restClient.Execute(restRequest);
            });
        }

        private Task AutorizarDoc_Enviar(string idDoc, string url, Dictionary<string, string> token)
        {
            return Task.Run(() =>
            {
                RestClient restClient = new RestClient($"{url}DocumentoEmitido/Enviar");
                restClient.Timeout = 90000;
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
            });
        }

        private Task AutorizarDoc_Recibir(string idDoc, string url, Dictionary<string, string> token)
        {
            return Task.Run(() =>
            {
                RestClient restClient = new RestClient($"{url}DocumentoEmitido/ActualizarEstado?id={idDoc}&fecha_desde=2017/01/01&fecha_hasta=2017/01/01");
                restClient.Timeout = 90000;
                RestRequest restRequest = new RestRequest(Method.GET);
                foreach (var row in token)
                {
                    restRequest.AddParameter(row.Key, row.Value, ParameterType.Cookie);
                }
                IRestResponse response = restClient.Execute(restRequest);
            });
        }
    }
}
