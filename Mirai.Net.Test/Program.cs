using System;
using System.Collections.Generic;
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
        private static void Main()
        {
            var t = new CommandTriggerAttribute("test");
            var input = "--name ahpx 1 2 3 --predicate --offset 7.0 --test3 awkjdb akjwhd awkjdh akjwh;d --test4 --test5 kahwd jkwajd          -test7 --test8";

            var re = t.ParseCommand(input);
            
            foreach (var keyValuePair in re)
            {
                Console.WriteLine(keyValuePair.Key);
                Console.WriteLine($"Length: {keyValuePair.Value.Length} Value: {string.Join(" ", keyValuePair.Value)}");
            }
        }

        public static Dictionary<string, string[]> Mock(CommandTriggerAttribute trigger, string command)
        {
            var split = command
                .Empty($"{trigger.Prefix}{trigger.Name}")
                .Trim()
                .Split(' ')
                .ToList();

            var re = new Dictionary<string, string[]>();
            //split be like(8): --name ahpx 1 2 3 --predicate --offset 7.0
            //indexes suppose:  0(--name),  5(--predicate), 6(--offset)
            //                  0           1               2

            var indexes = new List<int>();

            
            split
                .Where(x => x.StartsWith(trigger.ArgsSeparator))
                .ToList()
                .ForEach(x => indexes.Add(split.IndexOf(x)));

            foreach (var index in indexes)
            {
                //if index == 0, next == 5, take 5
                //if index == 5, next == 6, take 0
                //if index == 6, next == 7, take 2
                int next;
                if (indexes.IndexOf(index) + 1 >= indexes.Count)
                {
                    next = split.Count - 1;
                }
                else
                {
                    next = indexes[indexes.IndexOf(index) + 1];
                }

                var range = new List<string>();
                var counts1 = split.Count - 1;
                if (next != counts1)
                {
                    range = split.GetRange(index, next - index);
                }
                else
                {
                    var last = split.Count - 1 - index;
                    range = split.GetRange(index, last + 1);
                }

                re.Add(range.First(), range.GetRange(1, range.Count - 1).ToArray());
            }

            return re;
        }
    }
}