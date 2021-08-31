using System;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            Console.WriteLine(0.1F+0.2F);
            // var bot = new MiraiBot
            // {
            //     Address = "localhost:8080",
            //     VerifyKey = "1145141919810",
            //     QQ = "2672886221"
            // };
            //
            // bot.Launch();
            //
            // var result = await HttpEndpoints.Verify.PostJsonAsync(new
            // {
            //     verifyKey = MiraiBot.Instance.VerifyKey
            // }, false);
            //
            // Console.WriteLine(result);
        }
    }
}