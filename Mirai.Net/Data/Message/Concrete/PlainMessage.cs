﻿using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class PlainMessage : MessageBase
    {
        [JsonProperty("text")]
        public string Text {get; set;}
        
        public override MessageType Type { get; init; } = MessageType.Plain;

        public PlainMessage(string text = null)
        {
            Text = text;
        }

        public static implicit operator PlainMessage(string s)
        {
            return new(s);
        }
    }
}