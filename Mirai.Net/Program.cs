using System;
using System.Threading.Tasks;
using Mirai.Net.Utilities;

namespace Mirai.Net
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine((await HttpUtility.Get("https://v1.jinrishici.com/all.txt")).Content);
        }
    }
}