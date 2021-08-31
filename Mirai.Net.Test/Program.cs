using System;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            var signal = new ManualResetEvent(false);
            
            var bot = new MiraiBot
            {
                Address = "localhost:8080",
                VerifyKey = "1145141919810",
                QQ = "2672886221"
            };
            
            
        }
    }
}