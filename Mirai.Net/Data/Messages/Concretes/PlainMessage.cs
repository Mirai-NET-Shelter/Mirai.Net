using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class PlainMessage : MessageBase
    {
        public PlainMessage(string text)
        {
            Text = text;
        }

        public PlainMessage()
        {
        }

        [JsonProperty("text")] public string Text { get; set; }

        public override Messages Type { get; set; } = Messages.Plain;
    }
}