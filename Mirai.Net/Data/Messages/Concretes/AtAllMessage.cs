namespace Mirai.Net.Data.Messages.Concretes
{
    public class AtAllMessage : MessageBase
    {
        public override Messages Type { get; set; } = Messages.AtAll;
    }
}