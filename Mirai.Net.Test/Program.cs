using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using CommandLine;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            IMyInterface myInterface = new MyClass();

            var att = myInterface
                .GetType()
                .GetMethod(nameof(myInterface.Test));

            Console.WriteLine(att.GetCustomAttributes<CommandTriggerAttribute>().First().Name);
        }
    }

    interface IMyInterface
    {
        [CommandTrigger(nameof(IMyInterface))]
        public void Test();
    }

    class MyClass : IMyInterface
    {
        public void Test()
        {
            
        }
    }
}