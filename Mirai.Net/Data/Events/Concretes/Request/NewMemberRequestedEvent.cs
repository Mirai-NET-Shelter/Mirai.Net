namespace Mirai.Net.Data.Events.Concretes.Request
{
    public class NewMemberRequestedEvent : RequestedEventBase
    {
        public override Events Type { get; set; } = Events.NewMemberRequested;
    }
}