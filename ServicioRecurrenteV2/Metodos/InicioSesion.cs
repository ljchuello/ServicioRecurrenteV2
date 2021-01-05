using System;
using System.Net;
using RestSharp;

namespace ServicioRecurrenteV2.Metodos
{
    public class InicioSesion
    {
        public string SessionId { set; get; } = string.Empty;
        public string RequestVerificationTokenCookie { set; get; } = string.Empty;
        public string RequestVerificationTokenBody { set; get; } = string.Empty;

        public void ST1_ObtenerCookies(string url)
        {
            try
            {
                var client = new RestClient($"{url}/Account/Login?ReturnUrl=%2F");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                // Set cookies
                SessionId = response.Cookies[0].Value;
                RequestVerificationTokenCookie = response.Cookies[1].Value;

                // Buscamos
                int comienza = response.Content.IndexOf("input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"");
                RequestVerificationTokenBody = response.Content.Substring(comienza+61, 108);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void ST2_IniciarSesion()
        {
            try
            {
                var client = new RestClient("http://local.sermatick.com:8080/Account/Login?ReturnUrl=%2F");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddParameter("ASP.NET_SessionId", SessionId, ParameterType.Cookie);
                request.AddParameter("__RequestVerificationToken", RequestVerificationTokenCookie, ParameterType.Cookie);
                request.AddParameter("__RequestVerificationToken", RequestVerificationTokenBody);
                request.AddParameter("Email", "admin@admin.com");
                request.AddParameter("Password", "123456");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
