using System;
using System.Linq;
using System.Reflection;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concrete;
using Newtonsoft.Json;

namespace Mirai.Net.Utilities.Extensions
{
    public static class MessageExtensions
    {
        public static MessageBase ToConcreteMessage(this string message)
        {
            var jObj = message.ToJObject();

            return jObj.GetPropertyValue("type") switch
            {
                "Source" => JsonConvert.DeserializeObject<SourceMessage>(message),
                "Quote" => JsonConvert.DeserializeObject<QuoteMessage>(message),
                "At" => JsonConvert.DeserializeObject<AtMessage>(message),
                "AtAll" => JsonConvert.DeserializeObject<AtAllMessage>(message),
                "Face" => JsonConvert.DeserializeObject<FaceMessage>(message),
                "Plain" => JsonConvert.DeserializeObject<PlainMessage>(message),
                "Image" => JsonConvert.DeserializeObject<ImageMessage>(message),
                "FlashImage" => JsonConvert.DeserializeObject<FlashImageMessage>(message),
                "Voice" => JsonConvert.DeserializeObject<VoiceMessage>(message),
                "Xml" => JsonConvert.DeserializeObject<XmlMessage>(message),
                "Json" => JsonConvert.DeserializeObject<JsonMessage>(message),
                "App" => JsonConvert.DeserializeObject<AppMessage>(message),
                "Poke" => JsonConvert.DeserializeObject<PokeMessage>(message),
                "Forward" => JsonConvert.DeserializeObject<ForwardMessage>(message),
                "File" => JsonConvert.DeserializeObject<FileMessage>(message),
                "MusicShare" => JsonConvert.DeserializeObject<MusicShareMessage>(message),
                _ => JsonConvert.DeserializeObject<MessageBase>(message)
            };
        }
    }
}