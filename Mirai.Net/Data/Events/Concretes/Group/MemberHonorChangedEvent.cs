using System.ComponentModel;
using System.Runtime.Serialization;
using Mirai.Net.Data.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberHonorChangedEvent : EventBase
    {
        public enum MemberHonorAction
        {
            [EnumMember(Value = "achieve")] [Description("achieve")]
            Achieve,

            [EnumMember(Value = "lose")] [Description("lose")]
            Lose
        }

        public override Events Type { get; set; } = Events.MemberHonorChanged;

        [JsonProperty("member")] public Member Member { get; set; }

        /// <summary>
        ///     获得还是失去称号
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MemberHonorAction Action { get; set; }

        /// <summary>
        ///     称号名称
        /// </summary>
        [JsonProperty("honor")]
        public string Honor { get; set; }
    }
}