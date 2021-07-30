namespace Mirai.Net.Data.Events.Concretes.Request
{
    public class NewInvitationRequestedEvent : RequestedEventBase
    {
        public override Events Type { get; set; } = Events.NewInvitationRequested;
    }
}