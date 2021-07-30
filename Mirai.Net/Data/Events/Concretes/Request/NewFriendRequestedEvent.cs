namespace Mirai.Net.Data.Events.Concretes.Request
{
    public class NewFriendRequestedEvent : RequestedEventBase
    {
        public override Events Type { get; set; } = Events.NewFriendRequested;
    }
}