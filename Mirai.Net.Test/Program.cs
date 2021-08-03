using System;
using System.IO;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using CommandLine;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
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
            using var exit = new ManualResetEvent(false);
            using var bot = new MiraiBot
            {
                Address = "localhost:8080",
                QQ = 2672886221,
                VerifyKey = "1145141919810"
            };

            await bot.Launch();

            bot.MessageReceived
                .Where(x => x.Type == MessageReceivers.Group)
                .Cast<GroupMessageReceiver>()
                .Subscribe(receiver =>
                {
                    foreach (var messageBase in receiver.MessageChain)
                    {
                        if (messageBase is PlainMessage plain)
                        {
                            Parser.Default
                                .ParseArguments<TestCommand, GeneralCommand>(plain.Text.Split(" "))
                                .WithParsed<TestCommand>(x => x.Executed(bot, messageBase, receiver))
                                .WithParsed<GeneralCommand>(x => x.Executed(bot, messageBase, receiver))
                                .WithNotParsed(x =>
                                {
                                    foreach (var error in x)
                                    {
                                        Console.WriteLine(error.Tag);
                                    }
                                });

                            break;
                        }
                    }
                });

            exit.WaitOne(TimeSpan.FromMinutes(3));
        }

        #region MyRegion

        // public class MyClass
        // {
        //     protected MyClass()
        //     {
        //         var json1 = new {Type = Events.GroupMessageRecalled}.ToJsonString();
        //         var json2 = new {Type = Events.Online, Name = "AHpx"}.ToJsonString();
        //         var json3 = new {Type = Events.Offline, Id = 114}.ToJsonString();
        //         var json4 = new {Type = Events.Dropped, IsShit = true}.ToJsonString();
        //
        //         var jsons = new[] {json1, json2, json3, json4};
        //         var types = new[] {typeof(MyClass2), typeof(MyClass3), typeof(MyClass4)};
        //
        //         var re = new List<MyClass>();
        //
        //         var instances = types.Select(x => Activator.CreateInstance(x) as MyClass);
        //
        //         foreach (var json in jsons)
        //         {
        //             var root = JsonConvert.DeserializeObject<MyClass>(json);
        //         
        //             foreach (var type in types)
        //             {
        //                 if (instances.Any(x => x.Type == root.Type))
        //                 {
        //                     var obj = instances.First(x => x.Type == root.Type);
        //
        //                     if (type == obj.GetType())
        //                     {
        //                         re.Add(JsonConvert.DeserializeObject(json, type) as MyClass);
        //                     }
        //                 }
        //             }
        //         }
        //     
        //         foreach (var myClass in re)
        //         {
        //             Console.WriteLine(myClass.ToJsonString());
        //         }
        //     }
        //     
        //     public virtual Events Type { get; set; }
        //
        //     public override string ToString()
        //     {
        //         return this.ToJsonString();
        //     }
        // }
        //
        // public class MyClass2 : MyClass
        // {
        //     public string Name { get; set; }
        //     public override Events Type { get; set; } = Events.Online;
        // }
        //
        // public class MyClass3 : MyClass
        // {
        //     public override Events Type { get; set; } = Events.Offline;
        //
        //     public int Id { get; set; } = 10;
        // }
        //
        // public class MyClass4 : MyClass
        // {
        //     public override Events Type { get; set; } = Events.Dropped;
        //
        //     public bool IsShit { get; set; }
        // }

        #endregion
    }
}