using System;
using System.Linq;
using System.Reflection;
using Mirai.Net.Data.Messages;

namespace Mirai.Net.Utilities.Extensions
{
    public static class MessageExtensions
    {
        public static string GetMessageType(this MessageBase messageBase)
        {
            return messageBase.Type;
        }
    }
}