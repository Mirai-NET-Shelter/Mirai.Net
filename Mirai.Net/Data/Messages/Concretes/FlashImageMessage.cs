namespace Mirai.Net.Data.Messages.Concretes
{
    public class FlashImageMessage : ImageMessage
    {
        public override Messages Type { get; set; } = Messages.FlashImage;
    }
}