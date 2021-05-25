using System.Threading.Tasks;
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
            return await RestClient.ExecuteAsync(new RestRequest(), Method.GET);
        }
    }
}