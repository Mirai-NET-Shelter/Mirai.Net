// ReSharper disable once CheckNamespace

using System.Collections.Generic;
using Mirai.Net.Data.Messages.Concretes;

namespace Mirai.Net.Data.Messages;

public partial class MessageChain
{
    public MessageChain(IEnumerable<MessageBase> collection) : base(collection)
    {
        AddRange(collection);
    }

    public MessageChain()
    {
    }
}