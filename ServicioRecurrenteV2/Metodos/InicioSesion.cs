using System;
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
                request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("Accept-Encoding", "gzip, deflate");
                request.AddHeader("Accept-Language", "es-ES,es;q=0.9");
                request.AddHeader("Cache-Control", "max-age=0");
                request.AddHeader("Connection", "Close");
                request.AddHeader("Content-Length", "175");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Cookie", $"ASP.NET_SessionId={SessionId}; __RequestVerificationToken={RequestVerificationTokenCookie}");
                request.AddHeader("DNT", "1");
                request.AddHeader("Host", "local.sermatick.com:8080");
                request.AddHeader("Origin", "http://local.sermatick.com:8080");
                request.AddHeader("Referer", "http://local.sermatick.com:8080/Account/Login?ReturnUrl=%2F");
                request.AddHeader("Upgrade-Insecure-Requests", "1");
                client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36";
                
                request.AddParameter("__RequestVerificationToken", $"{RequestVerificationTokenBody}");
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
