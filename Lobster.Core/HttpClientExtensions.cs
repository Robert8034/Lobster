using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lobster.Core.Data;
using Lobster.Core.Domain;
using Newtonsoft.Json;

namespace Lobster.Core
{
    public static class HttpClientExtensions
    {

        private const string ConnectionString = "https://localhost:5001/";
     
        public static async Task<RestResponse> PostJsonAsync<T>(this HttpClient httpClient, string url, object data, Type type) => await httpClient.SendJsonAsync<T>(HttpMethod.Post, url, data, type);

        public static async Task<RestResponse> GetJsonAsync<T>(this HttpClient httpClient, string url, Type type)
        {
            var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, ConnectionString + url));

            var stringContent = await response.Content.ReadAsStringAsync();

            RestResponse restResponse = JsonConvert.DeserializeObject<RestResponse>(stringContent);
            if (restResponse.ResponseObject != null) restResponse.ResponseObject = JsonConvert.DeserializeObject(restResponse.ResponseObject.ToString(), type);
            return restResponse;
        }

        public static async Task<RestResponse> SendJsonAsync<T>(this HttpClient httpClient, HttpMethod method, string url, object data, Type type)
        {
            var response = await httpClient.SendAsync(new HttpRequestMessage(method, ConnectionString + url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(data).ToString(), Encoding.UTF8, "application/json")
            });

            var stringContent = await response.Content.ReadAsStringAsync();

            RestResponse restResponse = JsonConvert.DeserializeObject<RestResponse>(stringContent);
            if (restResponse.ResponseObject != null) restResponse.ResponseObject = JsonConvert.DeserializeObject(restResponse.ResponseObject.ToString(), type);
            return restResponse;
        }
    }
}
