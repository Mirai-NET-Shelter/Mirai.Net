using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;

namespace Mirai.Net.Utils.Scaffolds;

public class MessageChainBuilder
{
    private readonly MessageChain _chain = new();

    /// <summary>
    /// 清除已追加的消息
    /// </summary>
    /// <returns></returns>
    public MessageChain Clear()
    {
        _chain.Clear();
        return _chain;
    }
    
    /// <summary>
    /// 追加一条文本消息
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public MessageChain Plain(string text)
    {
        _chain.Add(new PlainMessage(text));
        return _chain;
    }
    
    /// <summary>
    /// 追加一条at消息
    /// </summary>
    /// <param name="qq"></param>
    /// <returns></returns>
    public MessageChain At(string qq)
    {
        _chain.Add(new AtMessage(qq));
        return _chain;
    }

    /// <summary>
    /// 追加一条app消息
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public MessageChain App(string content)
    {
        _chain.Add(new AppMessage(content));
        return _chain;
    }

    /// <summary>
    /// 追加一套at全体成员消息
    /// </summary>
    /// <returns></returns>
    public MessageChain AtAll()
    {
        _chain.Add(new AtAllMessage());

        return _chain;
    }

    /// <summary>
    /// 追加一条骰子消息
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public MessageChain Dice(string value)
    {
        _chain.Add(new DiceMessage
        {
            Value = value
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加图片消息
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public MessageChain ImageFromUrl(string url)
    {
        _chain.Add(new ImageMessage
        {
            Url = url
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加图片消息
    /// </summary>
    /// <param name="base64"></param>
    /// <returns></returns>
    public MessageChain ImageFromBase64(string base64)
    {
        _chain.Add(new ImageMessage
        {
            Base64 = base64
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加图片消息
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public MessageChain ImageFromPath(string file)
    {
        _chain.Add(new ImageMessage
        {
            Path = file
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加图片消息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public MessageChain ImageFromId(string id)
    {
        _chain.Add(new ImageMessage
        {
            ImageId = id
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加图片消息
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public MessageChain FlashImageFromUrl(string url)
    {
        _chain.Add(new FlashImageMessage
        {
            Url = url
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加闪照消息
    /// </summary>
    /// <param name="base64"></param>
    /// <returns></returns>
    public MessageChain FlashImageFromBase64(string base64)
    {
        _chain.Add(new FlashImageMessage
        {
            Base64 = base64
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加闪照消息
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public MessageChain FlashImageFromPath(string file)
    {
        _chain.Add(new FlashImageMessage
        {
            Path = file
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加闪照消息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public MessageChain FlashImageFromId(string id)
    {
        _chain.Add(new FlashImageMessage
        {
            ImageId = id
        });

        return _chain;
    }

    /// <summary>
    /// 追加json消息
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public MessageChain Json(string json)
    {
        _chain.Add(new JsonMessage
        {
            Json = json
        });

        return _chain;
    }

    /// <summary>
    /// 追加xml消息
    /// </summary>
    /// <param name="xml"></param>
    /// <returns></returns>
    public MessageChain Xml(string xml)
    {
        _chain.Add(new XmlMessage
        {
            Xml = xml
        });

        return _chain;
    }

    /// <summary>
    /// 追加一条语音消息
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public MessageChain VoiceFromPath(string path)
    {
        _chain.Add(new VoiceMessage
        {
            Path = path
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加一条语音消息
    /// </summary>
    /// <param name="base64"></param>
    /// <returns></returns>
    public MessageChain VoiceFromBase64(string base64)
    {
        _chain.Add(new VoiceMessage
        {
            Base64 = base64
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加一条语音消息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public MessageChain VoiceFromId(string id)
    {
        _chain.Add(new VoiceMessage
        {
            VoiceId = id
        });

        return _chain;
    }
    
    /// <summary>
    /// 追加一条语音消息
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public MessageChain VoiceFromUrl(string url)
    {
        _chain.Add(new VoiceMessage
        {
            Url = url
        });

        return _chain;
    }
    
}