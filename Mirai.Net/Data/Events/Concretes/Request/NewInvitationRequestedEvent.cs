namespace Mirai.Net.Data.Events.Concretes.Request
{
    public class NewInvitationRequestedEvent : RequestedEventBase
    {
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Events Type { get; set; } = Events.NewInvitationRequested;
    }
}