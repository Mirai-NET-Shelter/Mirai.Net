using System.ComponentModel;
using System.Runtime.Serialization;
using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberHonorChangedEvent : EventBase
    {
        public override Events Type { get; set; } = Events.MemberHonorChanged;
        
        [JsonProperty("member")]
        public Member Member {get; set;}
        
        /// <summary>
        /// 获得还是失去称号
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public MemberHonorAction Action {get; set;}
        
        /// <summary>
        /// 称号名称
        /// </summary>
        [JsonProperty("honor")]
        public string Honor {get; set;}
        
        public enum MemberHonorAction
        {
            [EnumMember(Value = "achieve")]
            [Description("achieve")]
            Achieve,
            [EnumMember(Value = "lose")]
            [Description("lose")]
            Lose
        }
    }
}