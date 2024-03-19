using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Shared;
using System;

namespace Mirai.Net.Utils.Scaffolds;

/// <summary>
/// 消息链建造者
/// </summary>
public class MessageChainBuilder
{
    private readonly MessageChain _chain = new();
    private bool _skipNext = false;

    /// <summary>
    /// 清除已追加的消息
    /// </summary>
    /// <returns></returns>
    public MessageChainBuilder Clear()
    {
        ExecuteOrSkip(_chain.Clear);
        return this;
    }

    /// <summary>
    /// 追加自定义的消息
    /// </summary>
    /// <param name="messageBase"></param>
    /// <returns></returns>
    public MessageChainBuilder Append(MessageBase messageBase)
    {
        ExecuteOrSkip(() => _chain.Add(messageBase));
        return this;
    }

    /// <summary>
    /// 追加一条文本消息
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public MessageChainBuilder Plain(string text)
    {
        ExecuteOrSkip(() => _chain.Add(new PlainMessage(text)));
        return this;
    }

    /// <summary>
    /// 追加一条at消息
    /// </summary>
    /// <param name="qq"></param>
    /// <returns></returns>
    public MessageChainBuilder At(string qq)
    {
        ExecuteOrSkip(() => _chain.Add(new AtMessage(qq)));
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
        ExecuteOrSkip(() => {
            _chain.Add(new AppMessage
            {
                Content = content
            });
        });
        return this;
    }

    /// <summary>
    /// 追加一套at全体成员消息
    /// </summary>
    /// <returns></returns>
    public MessageChainBuilder AtAll()
    {
        ExecuteOrSkip(() => _chain.Add(new AtAllMessage()));
        return this;
    }

    /// <summary>
    /// 追加一条骰子消息
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public MessageChainBuilder Dice(string value)
    {
        ExecuteOrSkip(() => {
            _chain.Add(new DiceMessage
            {
                Value = value
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new ImageMessage
            {
                Url = url
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new ImageMessage
            {
                Base64 = base64
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new ImageMessage
            {
                Path = file
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new ImageMessage
            {
                ImageId = id
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new FlashImageMessage
            {
                Url = url
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new FlashImageMessage
            {
                Base64 = base64
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new FlashImageMessage
            {
                Path = file
            });
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
        ExecuteOrSkip(() =>
        {
            _chain.Add(new FlashImageMessage
            {
                ImageId = id
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new JsonMessage
            {
                Json = json
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new XmlMessage
            {
                Xml = xml
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new VoiceMessage
            {
                Path = path
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new VoiceMessage
            {
                Base64 = base64
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new VoiceMessage
            {
                VoiceId = id
            });
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
        ExecuteOrSkip(() => {
            _chain.Add(new VoiceMessage
            {
                Url = url
            });
        });
        return this;
    }

    /// <summary>
    /// 建造消息链
    /// </summary>
    /// <returns></returns>
    public MessageChain Build()
    {
        //Build方法无视_skipNext的值，直接返回消息链
        return _chain;
    }

    /// <summary>
    /// 判断条件，如果为false，则跳过下一个元素
    /// </summary>
    /// <returns></returns>
    public MessageChainBuilder If(bool condition)
    {
        _skipNext = !condition;
        return this;
    }

    // 中间方法，根据_skipNext的值决定是否执行传入的操作
    private void ExecuteOrSkip(Action action)
    {
        if (!_skipNext) 
            action.Invoke();
        _skipNext = false;  // Reset the skip flag after each operation
    }
}