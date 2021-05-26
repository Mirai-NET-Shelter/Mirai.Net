using System.Threading.Tasks;
using Mirai.Net.Utilities.Extensions;
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

            return await RestClient.ExecuteAsync(request, Method.POST);
        }
    }
}