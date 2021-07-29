using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;
using Newtonsoft.Json;
using Websocket.Client;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            // var exit = new ManualResetEvent(false);
            // using var bot = new MiraiBot
            // {
            //     Address = "localhost:8080",
            //     QQ = 2672886221,
            //     VerifyKey = "1145141919810"
            // };
            //
            // await bot.Launch();
            // Console.WriteLine(await bot.GetPluginVersion());
            //
            // exit.WaitOne(TimeSpan.FromSeconds(30));

            var json1 = new {Type = Events.GroupMessageRecalled}.ToJsonString();
            var json2 = new {Type = Events.Online, Name = "AHpx"}.ToJsonString();
            var json3 = new {Type = Events.Offline, Id = 114}.ToJsonString();
            var json4 = new {Type = Events.Dropped, IsShit = true}.ToJsonString();

            var jsons = new[] {json1, json2, json3, json4};
            var types = new[] {typeof(MyClass2), typeof(MyClass3), typeof(MyClass4)};

            var re = new List<MyClass>();
            foreach (var json in jsons)
            {
                var root = JsonConvert.DeserializeObject<MyClass>(json);
                
                foreach (var type in types)
                {
                    var obj = JsonConvert.DeserializeObject(json, type);

                    Console.WriteLine(obj.ToJsonString());

                    var value = obj?.GetType().GetProperty("Type")?.GetValue(obj, null);
                    if (value is Events events)
                    {
                        if (root.Type == events)
                        {
                            re.Add(obj as MyClass);
                        }
                    }
                }
            }
            
            // foreach (var myClass in re)
            // {
            //     Console.WriteLine(myClass.ToJsonString());
            // }
        }

        public class MyClass
        {
            protected MyClass()
            {
            }

            public virtual Events Type { get; set; }

            public override string ToString()
            {
                return this.ToJsonString();
            }
        }
        
        public class MyClass2 : MyClass
        {
            public string Name { get; set; }
            public override Events Type { get; set; } = Events.Online;
        }

        public class MyClass3 : MyClass
        {
            public override Events Type { get; set; } = Events.Offline;

            public int Id { get; set; } = 10;
        }
        
        public class MyClass4 : MyClass
        {
            public override Events Type { get; set; } = Events.Dropped;

            public bool IsShit { get; set; }
        }
    }
}