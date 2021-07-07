namespace Mirai.Net.Data.Message.Concrete
{
    public class AtAllMessage : MessageBase
    {
        public override MessageType Type { get; init; } = MessageType.AtAll;
    }
}