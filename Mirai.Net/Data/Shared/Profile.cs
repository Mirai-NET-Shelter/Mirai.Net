using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Shared;

/// <summary>
/// 资料卡
/// </summary>
public class Profile
{
    /// <summary>
    /// 昵称
    /// </summary>
    [JsonProperty("nickname")] public string NickName { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [JsonProperty("email")] public string Email { get; set; }

    /// <summary>
    /// 年龄
    /// </summary>
    [JsonProperty("age")] public string Age { get; set; }

    /// <summary>
    /// 等级
    /// </summary>
    [JsonProperty("level")] public string Level { get; set; }

    /// <summary>
    ///     签名
    /// </summary>
    [JsonProperty("sign")]
    public string Signature { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [JsonProperty("sex")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Genders Gender { get; set; }
}