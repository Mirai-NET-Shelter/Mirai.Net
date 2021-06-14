using System.IO;
using System.Threading.Tasks;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Mirai.Net.Utilities
{
    internal static class HttpUtility
    {
        private static readonly RestClient RestClient;
        static HttpUtility()
        {
            RestClient = new RestClient();
        }

        internal static async Task<IRestResponse> Get(string url)
        {
            RestClient.BaseUrl = url.ToUri();
            return await RestClient.ExecuteAsync(new RestRequest(), Method.GET);
        }

        internal static async Task<IRestResponse> Post(string url, object content)
        {
            RestClient.BaseUrl = url.ToUri();

            var request = new RestRequest();
            request.AddJsonBody(content);
            request.AddHeader("charset", "utf-8");

            return await RestClient.ExecuteAsync(request, Method.POST);
        }

        public static async Task<IRestResponse> Post(string url, byte[] file, object json)
        {
            RestClient.BaseUrl = url.ToUri();

            var jObj = json.ToJObject();

            var request = new RestRequest();

            request.AddFileBytes(jObj.GetPropertyValue("fileName"), file, jObj.GetPropertyValue("fileName"));
            
            foreach (var token in JArray.Parse(jObj.GetPropertyValue("parameters")))
            {
                request.AddParameter(token.GetPropertyValue("key"), token.GetPropertyValue("value"));
            }
            // request.AddParameter("sessionKey", jObj.GetPropertyValue("sessionKey"));
            // request.AddParameter("type", jObj.GetPropertyValue("type"));
            request.AddHeader("Content-Type", "multipart/form-data");
            
            return await RestClient.ExecuteAsync(request, Method.POST);
        }
        
        public static async Task<IRestResponse> Post(string url, string file, object json)
        {
            return await Post(url, await File.ReadAllBytesAsync(file), json);
        }
    }
}