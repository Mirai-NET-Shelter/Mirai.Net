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
    }
}