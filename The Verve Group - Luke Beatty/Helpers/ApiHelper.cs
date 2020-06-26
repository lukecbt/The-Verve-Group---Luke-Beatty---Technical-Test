using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using The_Verve_Group___Luke_Beatty.Models;

namespace The_Verve_Group___Luke_Beatty.Helpers
{
    public class ApiHelper
    {
        public T GetResultFromApi<T>(string url)
        {
            // Make a GET method call to the specified API url and return result as a deserialised object of the type specified
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Request");
                Task<String> response = httpClient.GetStringAsync(url);
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response.Result)).Result;
            }
        }

        public IEnumerable<T> GetResultFromApiEnum<T>(string url)
        {
            // Make a GET method call to the specified API url and return result as a deserialised object of the type specified
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Request");
                Task<String> response = httpClient.GetStringAsync(url);
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<T>>(response.Result)).Result;
            }
        }
    }
}