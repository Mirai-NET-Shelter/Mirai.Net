---
layout: post
title:  快速开始
---

## 安装

+ 自行编译源代码
+ 使用[nuget](https://www.nuget.org/packages/Mirai.Net/1.0.0) 
  + ```<PackageReference Include="Mirai.Net" Version="1.0.0" />```
  + ```Install-Package Mirai.Net -Version 1.0.0```
  + ```dotnet add package Mirai.Net --version 1.0.0```

## Hello, World

最核心的Bot类是一个静态类，也就是说此类有且仅有一个对象。所以，要访问此类的成员，只需要使用```<类名>.<成员>```的方式即可。

#### 配置Session

除了机器人的QQ号之外，其它3个属性的值都来自于config\net.mamoe.mirai-api-http\setting.yml文件。

```c#
Bot.Session = new MiraiSession
{
    Host = "host",
    Port = "port",
    Key = "authKey", //Guid.NewGuid()
    QQ = "机器人的QQ号"
};
```

#### 连接插件

在这之后，调用```Launch```方法来和mirai-api-http插件建立连接。

```c#
await Bot.Launch();
```

#### 发送消息

最后，构造一个```GroupMessenger```对象，再调用它的```Send```方法，传入[消息链](what-is-message-chain)即可发送一条消息到指定群聊。

```c#
var groupMessenger = new GroupMessenger("QQ群号");
await groupMessenger.Send(new PlainMessage("Hello, World"));
```

