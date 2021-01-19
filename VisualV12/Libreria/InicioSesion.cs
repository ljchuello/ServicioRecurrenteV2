using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace VisualV12.Libreria
{
    public class InicioSesion
    {
        private string SessionId = string.Empty;
        private string RequestVerificationTokenCookie = string.Empty;
        private string RequestVerificationTokenBody = string.Empty;

        private readonly oResultado oResultado = new oResultado();

        public oResultado GetToken(string url, string correo, string contrasenia)
        {
            try
            {
                ST1_ObtenerCookies(url);
                return oResultado.Exitoso(ST2_IniciarSesion(url, correo, contrasenia));
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

        public Dictionary<string, string> ST2_IniciarSesion(string url, string usuario, string contrasenia)
        {
            var client = new RestClient($"{url}/Account/Login?ReturnUrl=%2F");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("ASP.NET_SessionId", SessionId, ParameterType.Cookie);
            request.AddParameter("__RequestVerificationToken", RequestVerificationTokenCookie, ParameterType.Cookie);
            request.AddParameter("__RequestVerificationToken", RequestVerificationTokenBody);
            request.AddParameter("Email", usuario);
            request.AddParameter("Password", contrasenia);
            client.CookieContainer = new CookieContainer();
            IRestResponse response = client.Execute(request);
            string cookie = client.CookieContainer.GetCookieHeader(new Uri($"{url}"));

            if (!response.Content.Contains("<title>Perfil de empresa | Sistema de Facturación Electrónica</title>"))
            {
                throw new Exception("Inicio de sesión incompleto");
            }

            Dictionary<string, string> galletas = new Dictionary<string, string>();
            galletas.Add(".AspNet.ApplicationCookie", cookie.Substring(26, 534));
            galletas.Add("ASP.NET_SessionId", SessionId);
            galletas.Add("__RequestVerificationToken", RequestVerificationTokenCookie);

            return galletas;
        }
    }
}
