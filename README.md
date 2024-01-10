# Mirai.Net 2.5.2

Mirai.NET 是基于 [mirai-api-http] 实现的 C# 版轻量级 [mirai] 社区 SDK。

此项目遵循 [AGPL-3.0](https://github.com/AHpxChina/Mirai.Net/blob/master/LICENSE) 协议开源。

QQ 群: [752379554](https://jq.qq.com/?_wv=1027&k=gdWqppEO)欢迎加入群聊探讨 ~~以及水群聊天~~

文档：[Mirai.Net Documents](https://sinoahpx.github.io/Mirai.Net.Documents)

如果你这个项目还不错，不妨考虑给它点一个 Star。

如果你还觉得挺酷但还不够好的话，也欢迎提交 Pull Request 和 Issue。

## 速览

- 基于 [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) 开发，支持跨平台。
- 适配最新的 [mirai-api-http] 插件。
- 实现了 [mirai-api-http] 的 `Http Adapter` 和 `Websocket Adapter`
  - `Http Adapter` 用来进行发送操作。
  - `Websocket Adapter` 用来进行接收操作。
- 基于 [Rx.NET](https://github.com/dotnet/reactive) 的推送系统。
- 有一堆好用的脚手架和拓展方法。
- 提供了简单的模块化和命令系统实现。
- 源代码结构
  - Mirai.Net，主项目
  - Mirai.Net.Test，控制台测试项目
  - Mirai.Net.UnitTest，单元测试项目（现在没啥用了）

## 快速上手

**(以下仅为一些简单示例，如果需要更详细的说明，请移步[文档]。有时候文档跟不上版本请[进群提问](#mirainet-239)**

### 安装

- 使用 Nuget 安装(推荐)
  - Nuget 包管理器: `Install-Package Mirai.Net`
  - .NET CLI: `dotnet add package Mirai.Net`
  - **或者在 IDE 的可视化界面搜索`Mirai.Net`安装最新版。**
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
    QQ = "xx",
    VerifyKey = "xx"
};
```

(因为`MiraiBot`类实现了`IDisposable`接口，所以可以使用`using`关键字)

`Address`和`VerifyKey`来自`mirai-api-http`的配置文件，`QQ`就是`Mirai Console`已登录的机器人的 QQ 号。

创建完`MiraiBot`实例之后，就可以启动了:

```cs
await bot.LaunchAsync();
```

### 监听事件和消息

`MiraiBot`类暴露两个属性: `EventReceived`和`MessageReceived`，订阅它们就可以监听事件和消息。

下面的例子就是过滤出接收到的`好友请求事件`事件，然后把它从`EventBase`转换成具体的`NewFriendRequestedEvent`，最后才是订阅器。

(消息的订阅器也是同样的)

```cs
bot.EventReceived
    .OfType<NewFriendRequestedEvent>()
    .Subscribe(x =>
    {
        //do things
    });
```

### Hello, World

`Mirai.Net`通过一系列的`xxManager`(**这些管理器都是静态类。**)来进行主动操作，其中，消息相关的管理器为`MessageManager`。

#### 发送消息

这里以发送群消息作为演示，实际上还可以发送好友消息，临时消息和戳一戳消息。

发送消息的方法有两个参数: 发送到哪里和发送什么。所以第一个参数就是发消息的群号，第二个参数就是要发送的消息链(或者字符串)。

```cs
await MessageManager.SendGroupMessageAsync("xx", "Hello, World");
```

或者:

```cs
await MessageManager.SendGroupMessageAsync("xx", new MessageChainBuilder().Plain("Hello, ").At("xx").Build());
```

## 贡献

此项目欢迎任何人的 [Pull Request](https://github.com/AHpxChina/Mirai.Net/pulls) 和 [Issue](https://github.com/AHpxChina/Mirai.Net/issues) 也欢迎 Star 和 Fork。

如果你认为文档不够好，也欢迎对 [文档仓库](https://github.com/SinoAHpx/Mirai.Net.Documents) 提交 [Pull Request](https://github.com/AHpxChina/Mirai.Net.Documents/pulls) 和 [Issue](https://github.com/AHpxChina/Mirai.Net.Documents/issues)。

## 致谢

- [mirai]
- [mirai-api-http]
- [Jetbrains](https://www.jetbrains.com/)
- [Flurl](https://flurl.dev/)
- [Json.NET](http://json.net/) ~~这甚至是这个项目名称的灵感来源~~
- [Websocket.Client](https://github.com/Marfusios/websocket-client)
- [Rx.NET](https://github.com/dotnet/reactive)
- [Manganese](https://github.com/SinoAHpx/Manganese)

[mirai-api-http]: https://github.com/project-mirai/mirai-api-http
[mirai]: https://github.com/mamoe/mirai
[文档]: https://sinoahpx.github.io/Mirai.Net.Documents/
