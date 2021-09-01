using System.Collections.Generic;
using System.Linq;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;

namespace Mirai.Net.Utils.Scaffolds
{
    /// <summary>
    /// 消息相关的脚手架
    /// </summary>
    public static class MessageScaffold
    {
        public static MessageBase[] Append(this string origin, params MessageBase[] append)
        {
            var re = new List<MessageBase> {new PlainMessage(origin)};
            re.AddRange(append);

            return re.ToArray();
        }

        public static MessageBase[] Append(this string origin, string append)
        {
            var re = new List<MessageBase> {new PlainMessage(origin), new PlainMessage(append)};

            return re.ToArray();
        }

        public static MessageBase[] Append(this MessageBase messageBase, params MessageBase[] append)
        {
            var re = new List<MessageBase> {messageBase};
            re.AddRange(append);

            return re.ToArray();
        }

        public static MessageBase[] Append(this MessageBase messageBase, string append)
        {
            var re = new List<MessageBase> {messageBase, new PlainMessage(append)};

            return re.ToArray();
        }

        public static MessageBase[] Append(this IEnumerable<MessageBase> bases, params MessageBase[] append)
        {
            var re = bases.ToList();
            re.AddRange(append);

            return re.ToArray();
        }

        public static MessageBase[] Append(this IEnumerable<MessageBase> bases, string append)
        {
            var re = bases.ToList();
            re.Add(new PlainMessage(append));

            return re.ToArray();
        }

        public static TResult[] WhereAndCast<TResult>(this IEnumerable<MessageBase> bases)
        {
            return bases.Where(x => x is TResult).Cast<TResult>().ToArray();
        }
    }
}