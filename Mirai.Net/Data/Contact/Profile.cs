using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Contact
{
    public class Profile
    {
        [JsonProperty("nickname")]
        public string NickName {get; set;}
        
        [JsonProperty("email")]
        public string Email {get; set;}
        
        [JsonProperty("age")]
        public string Age {get; set;}
        
        [JsonProperty("level")]
        public string Level {get; set;}
        
        /// <summary>
        /// 签名
        /// </summary>
        [JsonProperty("sign")]
        public string Signature {get; set;}
        
        [JsonProperty("sex")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProfileGender Gender {get; set;}
    }

    public enum ProfileGender
    {
        [EnumMember(Value = "MALE")]
        Male,
        [EnumMember(Value = "FEMALE")]
        Female,
        [EnumMember(Value = "UNKNOWN")]
        Unknown
    }
}