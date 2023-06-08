using Manganese.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Mirai.Net.Data.Messages.Concretes;

namespace Mirai.Net.Data.Messages;

/// <summary>
/// 所有消息的基类
/// </summary>
public record MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual Messages Type { get; set; }

    /// <summary>
    /// 实际上是转换成json文本
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.ToJsonString();
    }

    /// <summary>
    /// 提供Mirai码序列化方法
    /// </summary>
    /// <returns></returns>
    public string SerializeToMiraiCode()
    {
        switch (this)
        {
            case PlainMessage msg:

                return msg.Text;

            case FlashImageMessage msg:

                return $"[mirai:flash:{msg.ImageId}]";

            case ImageMessage msg:

                if (string.IsNullOrEmpty(msg.ImageId))
                    throw new("ImageId为空！");

                else
                    return $"[mirai:image:{msg.ImageId}]";

            case AtMessage msg:

                return $"[mirai:at:{msg.Target}]";

            case AtAllMessage msg:

                return "[mirai:atall]";

            case FaceMessage msg:

                if (string.IsNullOrEmpty(msg.FaceId))
                    throw new("FaceId为空！");

                else
                    return $"[mirai:face:{msg.FaceId}]";

            case PokeMessage msg:

                return $"""
                [mirai:poke:{msg.Name switch
                {
                    "Poke" => "戳一戳,1,-1",

                    "ShowLove" => "比心,2,-1",

                    "Like" => "点赞,3,-1",

                    "Heartbroken" => "心碎,4,-1",

                    "SixSixSix" => "666,5,-1",

                    "FangDaZhao" => "放大招,6,-1",

                    _ => throw new("该Poke消息还未支持！")
                }}]
                """;

            case DiceMessage msg:

                return $"[mirai:dice:{msg.Value}]";

            case MusicShareMessage msg: // MusicShare在mirai的2.15.0-M1版本中显示为[mirai:origin:MUSIC_SHARE]MusicShare(*这里有一长串省略的内容) 与https://github.com/mamoe/mirai/blob/dev/docs/Messages.md中所说的[mirai:musicshare:$args]不符 因此这里先采用后者的方式 使用半角逗号分隔 至少保证序列化的稳定

                return $"[mirai:musicshare:{msg.Kind},{msg.Title},{msg.Summary},{msg.JumpUrl},{msg.PictureUrl},{msg.MusicUrl},{msg.Brief}]";

            case FileMessage msg: // FileMessage由于缺少参数(InternalId)目前是实验性功能 该参数自动使用Id补全

                return $"[mirai:file:{msg.FileId},{msg.FileId},{msg.Name},{msg.Size}]";

            default:

                throw new("遇到了不支持序列化的消息！");
        }
    }

    /// <summary>
    /// 自动转换成消息链
    /// </summary>
    /// <param name="msg1"></param>
    /// <param name="msg2"></param>
    /// <returns></returns>
    public static MessageChain operator +(MessageBase msg1, MessageBase msg2)
    {
        return new MessageChain { msg1, msg2 };
    }
}