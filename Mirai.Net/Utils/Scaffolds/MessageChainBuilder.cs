using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Shared;

namespace Mirai.Net.Utils.Scaffolds;

/// <summary>
/// 消息链建造者
/// </summary>
public class MessageChainBuilder
{
    private readonly MessageChain _chain = new();

    /// <summary>
    /// 清除已追加的消息
    /// </summary>
    /// <returns></returns>
    public MessageChainBuilder Clear()
    {
        _chain.Clear();
        return this;
    }

    /// <summary>
    /// 追加自定义的消息
    /// </summary>
    /// <param name="messageBase"></param>
    /// <returns></returns>
    public MessageChainBuilder Append(MessageBase messageBase)
    {
        _chain.Add(messageBase);
        return this;
    }

    /// <summary>
    /// 追加一条文本消息
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public MessageChainBuilder Plain(string text)
    {
        _chain.Add(new PlainMessage(text));
        return this;
    }

    /// <summary>
    /// 追加一条at消息
    /// </summary>
    /// <param name="qq"></param>
    /// <returns></returns>
    public MessageChainBuilder At(string qq)
    {
        _chain.Add(new AtMessage(qq));
        return this;
    }

    /// <summary>
    /// 追加一条at消息
    /// </summary>
    /// <param name="member"></param>
    /// <returns></returns>
    public MessageChainBuilder At(Member member)
    {
        return At(member.Id);
    }

    /// <summary>
    /// 追加一条app消息
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public MessageChainBuilder App(string content)
    {
        _chain.Add(new AppMessage
        {
            Content = content
        });
        return this;
    }

    /// <summary>
    /// 追加一套at全体成员消息
    /// </summary>
    /// <returns></returns>
    public MessageChainBuilder AtAll()
    {
        _chain.Add(new AtAllMessage());

        return this;
    }

    /// <summary>
    /// 追加一条骰子消息
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public MessageChainBuilder Dice(string value)
    {
        _chain.Add(new DiceMessage
        {
            Value = value
        });

        return this;
    }

    /// <summary>
    /// 追加图片消息
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public MessageChainBuilder ImageFromUrl(string url)
    {
        _chain.Add(new ImageMessage
        {
            Url = url
        });

        return this;
    }

    /// <summary>
    /// 追加图片消息
    /// </summary>
    /// <param name="base64"></param>
    /// <returns></returns>
    public MessageChainBuilder ImageFromBase64(string base64)
    {
        _chain.Add(new ImageMessage
        {
            Base64 = base64
        });

        return this;
    }

    /// <summary>
    /// 追加图片消息
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public MessageChainBuilder ImageFromPath(string file)
    {
        _chain.Add(new ImageMessage
        {
            Path = file
        });

        return this;
    }

    /// <summary>
    /// 追加图片消息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public MessageChainBuilder ImageFromId(string id)
    {
        _chain.Add(new ImageMessage
        {
            ImageId = id
        });

        return this;
    }

    /// <summary>
    /// 追加图片消息
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public MessageChainBuilder FlashImageFromUrl(string url)
    {
        _chain.Add(new FlashImageMessage
        {
            Url = url
        });

        return this;
    }

    /// <summary>
    /// 追加闪照消息
    /// </summary>
    /// <param name="base64"></param>
    /// <returns></returns>
    public MessageChainBuilder FlashImageFromBase64(string base64)
    {
        _chain.Add(new FlashImageMessage
        {
            Base64 = base64
        });

        return this;
    }

    /// <summary>
    /// 追加闪照消息
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public MessageChainBuilder FlashImageFromPath(string file)
    {
        _chain.Add(new FlashImageMessage
        {
            Path = file
        });

        return this;
    }

    /// <summary>
    /// 追加闪照消息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public MessageChainBuilder FlashImageFromId(string id)
    {
        _chain.Add(new FlashImageMessage
        {
            ImageId = id
        });

        return this;
    }

    /// <summary>
    /// 追加json消息
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public MessageChainBuilder Json(string json)
    {
        _chain.Add(new JsonMessage
        {
            Json = json
        });

        return this;
    }

    /// <summary>
    /// 追加xml消息
    /// </summary>
    /// <param name="xml"></param>
    /// <returns></returns>
    public MessageChainBuilder Xml(string xml)
    {
        _chain.Add(new XmlMessage
        {
            Xml = xml
        });

        return this;
    }

    /// <summary>
    /// 追加一条语音消息
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public MessageChainBuilder VoiceFromPath(string path)
    {
        _chain.Add(new VoiceMessage
        {
            Path = path
        });

        return this;
    }

    /// <summary>
    /// 追加一条语音消息
    /// </summary>
    /// <param name="base64"></param>
    /// <returns></returns>
    public MessageChainBuilder VoiceFromBase64(string base64)
    {
        _chain.Add(new VoiceMessage
        {
            Base64 = base64
        });

        return this;
    }

    /// <summary>
    /// 追加一条语音消息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public MessageChainBuilder VoiceFromId(string id)
    {
        _chain.Add(new VoiceMessage
        {
            VoiceId = id
        });

        return this;
    }

    /// <summary>
    /// 追加一条语音消息
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public MessageChainBuilder VoiceFromUrl(string url)
    {
        _chain.Add(new VoiceMessage
        {
            Url = url
        });

        return this;
    }

    /// <summary>
    /// 建造消息链
    /// </summary>
    /// <returns></returns>
    public MessageChain Build()
    {
        return _chain;
    }
}