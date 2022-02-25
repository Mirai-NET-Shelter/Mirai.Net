// ReSharper disable once CheckNamespace

using System.Collections.Generic;
using System.Linq;
using Mirai.Net.Data.Messages.Concretes;

namespace Mirai.Net.Data.Messages;

public partial class MessageChain
{
    public MessageChain(IEnumerable<MessageBase> collection) : base(collection)
    {
    }

    public MessageChain()
    {
    }
}