using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Consola.Models
{
    public class ApiCall 
    {
        private readonly string URL_API = ConfigurationManager.AppSettings["URL_API"];

        private static HttpSessionStateBase HttpSession;

        public ApiCall(HttpSessionStateBase httpSession)
        {
            HttpSession = httpSession;
        }

        public async Task<HttpResponseMessage> PostAsync(string path, object content)
        {
            var client = AgregarToken();
            StringContent jsonContent = FormatoContenido(content);
            var respuesta = await client.PostAsync(path, jsonContent);
            return respuesta;
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            var client = AgregarToken();
            var respuesta = await client.GetAsync(path);
            return respuesta;
        }

        public async Task<HttpResponseMessage> PutAsync(string path, object content)
        {
            var client = AgregarToken();
            StringContent jsonContent = FormatoContenido(content);
            var respuesta = await client.PutAsync(path, jsonContent);
            return respuesta;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string path)
        {
            var client = AgregarToken();
            var respuesta = await client.DeleteAsync(path);
            return respuesta;
        }

        private HttpClient AgregarToken()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(URL_API);
            if (HttpSession["token"] != null)
            {
                var token = HttpSession["token"].ToString(); 
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        private StringContent FormatoContenido(object content)
        {
            var json = JsonConvert.SerializeObject(content);
            StringContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            return jsonContent;
        }
    }
}