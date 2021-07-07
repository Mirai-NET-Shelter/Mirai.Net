namespace Mirai.Net.Data.Message.Concrete
{
    public class FlashImageMessage : ImageMessage
    {
        public override MessageType Type { get; init; } = MessageType.FlashImage;
    }
}