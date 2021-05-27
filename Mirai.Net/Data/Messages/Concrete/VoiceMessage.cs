using System;
using Mirai.Net.Data.Messages.Enums;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class VoiceMessage : MessageBase
    {
        public override string Type { get; set; } = "Voice";
        
        [JsonProperty("voiceId")]
        public string VoiceId {get; set;}
        
        [JsonProperty("url")]
        public string Url {get; set;}
        
        [JsonProperty("path")]
        public string Path {get; set;}

        public VoiceMessage(string param = null, VoiceMessageType voiceMessageType = VoiceMessageType.Url)
        {
            _ = voiceMessageType switch
            {
                VoiceMessageType.Url => Url = param,
                VoiceMessageType.Path => Path = param,
                VoiceMessageType.Id => VoiceId = param,
                _ => throw new ArgumentOutOfRangeException(nameof(voiceMessageType), voiceMessageType, null)
            };
        }
    }
}