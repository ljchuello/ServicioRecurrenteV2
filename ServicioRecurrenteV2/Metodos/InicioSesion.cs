using System;
using System.Net;
using RestSharp;

namespace ServicioRecurrenteV2.Metodos
{
    public class InicioSesion
    {
        private string SessionId = string.Empty;
        private string RequestVerificationTokenCookie = string.Empty;
        private string RequestVerificationTokenBody = string.Empty;

        private readonly oResultado oResultado = new oResultado();

        public oResultado GetToken(string url)
        {
            try
            {
                ST1_ObtenerCookies(url);
                ST2_IniciarSesion(url);
                return oResultado.Exitoso();
            }
            catch (Exception ex)
            {
                return oResultado.Fallido(ex.Message);
            }
        }

        public void ST1_ObtenerCookies(string url)
        {
            var client = new RestClient($"{url}/Account/Login?ReturnUrl=%2F");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // Set cookies
            SessionId = response.Cookies[0].Value;
            RequestVerificationTokenCookie = response.Cookies[1].Value;

            // Buscamos
            int comienza = response.Content.IndexOf("input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"", StringComparison.Ordinal);
            RequestVerificationTokenBody = response.Content.Substring(comienza + 61, 108);
        }

        public void ST2_IniciarSesion(string url)
        {
            var client = new RestClient($"{url}/Account/Login?ReturnUrl=%2F");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("ASP.NET_SessionId", SessionId, ParameterType.Cookie);
            request.AddParameter("__RequestVerificationToken", RequestVerificationTokenCookie, ParameterType.Cookie);
            request.AddParameter("__RequestVerificationToken", RequestVerificationTokenBody);
            request.AddParameter("Email", "admin@admin.comm");
            request.AddParameter("Password", "123456");
            client.CookieContainer = new CookieContainer();
            IRestResponse response = client.Execute(request);
            var cookie = client.CookieContainer.GetCookieHeader(new Uri($"{url}"));
            if (!response.Content.Contains("<title>Perfil de empresa | Sistema de Facturación Electrónica</title>"))
            {
                throw new Exception("Inicio de sesión incompleto");
            }
        }
    }
}
