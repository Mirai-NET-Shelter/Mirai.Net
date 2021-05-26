using System;
using System.Threading.Tasks;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(new {authkey = "awdawd"}.ToJson());
        }
    }
}