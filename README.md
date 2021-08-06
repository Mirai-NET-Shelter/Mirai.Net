# Mirai.Net 2.2.0

Mirai.Net 是基于[mirai-api-http]实现的轻量级[mirai]社区 sdk。 此项目遵循
[AGPL-3.0 LICENSE](https://github.com/AHpxChina/Mirai.Net/blob/master/LICENSE)
开源。

## 速览

- 基于 [.Net Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) 开发，支持跨平台。
- 适配最新的[mirai-api-http]插件。
- 实现了[mirai-api-http]的`Http Adapter`和`Websocket Adapter`
  - `Http Adapter`用来进行发送操作。
  - `Websocket Adapter`用来进行接收操作。
- 基于 [Rx.Net](https://github.com/dotnet/reactive) 的推送系统。
- 有一堆好用的脚手架和拓展方法。
- 源代码结构
  - Mirai.Net，主项目
  - Mirai.Net.Test，控制台测试项目
  - Mirai.Net.Helium，实战测试项目
  - Mirai.Net.UnitTest，单元测试项目

<details>
  <summary>实现的接口列表</summary>

_斜体的标注的接口是不稳定的_

~~删除线标注的接口是未实现的~~

- 账号信息
  - 获取好友列表
  - 获取群列表
  - 获取群成员列表
  - 获取 Bot 资料
  - 获取好友资料
  - 获取群成员资料
- 消息发送和撤回
  - 发送好友消息
  - 发送群消息
  - 发送临时会话消息
  - 发送头像戳一戳消息
  - 撤回消息
- 文件操作
  - _查看文件列表_
  - _获取文件信息_
  - _创建文件夹_
  - ~~删除文件~~
  - ~~移动文件~~
  - ~~重命名文件~~
- 多媒体内容上传
  - 图片文件上传
  - 语音文件上传
  - 群文件上传
- 账号管理
  - 删除好友
- 群管理
  - 禁言群成员
  - 解除群成员禁言
  - 移除群成员
  - 退出群聊
  - 全体禁言
  - 解除全体禁言
  - 设置群精华消息
  - 获取群设置
  - 修改群设置
  - 获取群员设置
  - 修改群员设置
- 事件处理
  - 添加好友申请
  - 用户入群申请
  - Bot 被邀请入群申请

</details>

<details>
  <summary>支持的消息类型</summary>

- Quote - 回复消息
- At - @消息
- AtAll - @全体成员
- Face - QQ 表情
- Plain - 纯文本
- Image - 图片
- FlashImage - 闪照
- Voice - 语音
- Xml - XML 消息
- Json - JSON 消息
- App - App 消息
- Poke - 戳一戳
- Dice - 不知道是啥玩意
- MusicShare - 音乐分享
- ForwardMessage - 转发消息
- File - 文件
</details>

## 快速上手

### 安装

- 使用 Nuget 安装(推荐)
  - Nuget 包管理器: `Install-Package Mirai.Net -Version 2.1.0`
  - .Net CLI: `dotnet add package Mirai.Net --version 2.1.0`
  - **或者在 IDE 的可视化界面搜索`Mirai.Net`安装。**
- 自己克隆这个仓库的默认分支，然后自己编译，然后自己添加 dll 引用。

### 创建和启动 Bot

<details>
  <summary>名称空间引用</summary>

```cs
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
```

</details>

```cs
using var bot = new MiraiBot
{
    Address = "localhost:8080",
    QQ = xx,
    VerifyKey = "xx"
};
```

(因为`MiraiBot`类实现了`IDisposable`接口，所以可以使用`using`关键字)

`Address`和`VerifyKey`来自`mirai-api-http`的配置文件，`QQ`就是`Mirai Console`已登录的机器人的 QQ 号。

创建完`MiraiBot`实例之后，就可以启动了:

```cs
await bot.Launch();
```

### 监听事件和消息

`MiraiBot`类暴露两个属性: `EventReceived`和`MessageReceived`，订阅它们就可以监听事件和消息。

下面的例子就是过滤出接收到的`好友请求事件`事件，然后把它从`EventBase`转换成具体的`NewFriendRequestedEvent`，最后才是订阅器。

(消息的订阅器也是同样的)

```cs
bot.EventReceived
    .Where(x => x.Type == Events.NewFriendRequested)
    .Cast<NewFriendRequestedEvent>()
    .Subscribe(x =>
    {
        //do things
    });
```

### Hello, World

`Mirai.Net`通过一系列的`xxManager`来进行主动操作，其中，消息相关的管理器为`MessageManager`。尽管这些管理器都可以直接实例化，但是不推荐这么做(主要是这样做不是很酷)。

#### 获取管理器

`Mirai.Net`将获取管理器的方法定义为`MiraiBot`类的拓展方法:

```cs
var manager = bot.GetManager<MessageManager>();
```

#### 发送消息

这里以发送群消息作为演示，实际上还可以发送好友消息，临时消息和戳一戳消息。

发送消息的方法有两个参数: 发送到哪里和发送什么。所以第一个参数就是发消息的群号，第二个参数就是要发送的消息链。

(因为第二个参数接收的是一个`params MessageBase[]`类型的参数，所以需要调用`Append`拓展方法把字符串转换成消息链。)

```cs
await manager.SendGroupMessage("xx", "Hello, World".Append());
```

或者:

```cs
await manager.SendGroupMessage("xx", "Hello, ".Append(new AtMessage("xx")).Append(" !"));
```

**以上仅为一些简单示例，如果想要知道更多，请移步[文档]。**

## 贡献

此项目欢迎任何人的[Pull Request](https://github.com/AHpxChina/Mirai.Net/pulls) 和[Issue](https://github.com/AHpxChina/Mirai.Net/issues)，也欢迎 Star 和 Fork。

另外，本项目的 QQ 群是: `1042821169`，如果需要技术支持或者有什么问题，可以加入群聊探讨。

## 致谢

- [mirai]
- [mirai-api-http]
- [Json.Net](http://json.net/) ~~这甚至是这个项目名称的灵感来源~~
- [Websocket.Client](https://github.com/Marfusios/websocket-client)
- [Rx.Net](https://github.com/dotnet/reactive)
- [AHpx.Extensions](https://github.com/AHpxChina/AHpx.Extensions)

[mirai-api-http]: https://github.com/project-mirai/mirai-api-http
[mirai]: https://github.com/mamoe/mirai
[文档]: https://ahpxchina.github.io/Mirai.Net.Documents/
