using CrudApiXamarin2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrudXamarin2.Helpers
{
    public class HttpHelper<T>
    {
        public async Task<ObservableCollection<T>> GetRestServiceDataAsync(string serviceAddress)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);

            //string contenido = await client.GetStringAsync(serviceAddress);

            client.BaseAddress = new Uri(serviceAddress);
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response =
                await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();
            var jsonResult =
                await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ObservableCollection<T>>(jsonResult);
            return result;
        }

        public async Task PostRestServiceDataAsync(T modelo, string serviceAddress)
        {            
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(serviceAddress);
            request.Method = HttpMethod.Post;
            request.Headers.Add("Accpect", "Application/json");
            var payload = JsonConvert.SerializeObject(modelo);
            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            request.Content = c;
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
        }

        public async Task PutRestServiceDataAsync(T modelo, string serviceAddress)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(serviceAddress);
            request.Method = HttpMethod.Put;
            request.Headers.Add("Accpect", "Application/json");
            var payload = JsonConvert.SerializeObject(modelo);
            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            request.Content = c;
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
        }

        public async Task DeleteRestServiceDataAsync(string serviceAddress)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(serviceAddress);
            request.Method = HttpMethod.Delete;
            request.Headers.Add("Accpect", "Application/json");            
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
        }

    }
}
