using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data;
using Mirai.Net.Data.Contact;
using Mirai.Net.Data.Events.Concrete.Args.Apply;
using Mirai.Net.Data.Events.Enums;
using Mirai.Net.Data.Messages;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace Mirai.Net
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static partial class Bot
    {
        private static MiraiSession _session;

        public static MiraiSession Session
        {
            get
            {
                if (_session == null)
                {
                    throw new NullReferenceException("Session can't be null!");
                }

                return _session;
            }
            set => _session = value;
        }

        public static IEnumerable<IModule> Modules { get; set; }

        private static WebSocket _webSocket;
        
        public static async Task Launch()
        {
            await Session.Connect();
            
            _webSocket = new WebSocket($"{_session.GetUrl(true)}/all?sessionKey={Session.SessionKey}");
            _webSocket.OnMessage += (sender, args) =>
            {
                if (args.Data.GetReceivedType())
                {
                    if (Modules != null)
                    {
                        foreach (var module in Modules)
                        {
                            var re = args.Data.ToObject<MessageReceivedArgs>();
                            var arr = JArray.Parse(args.Data.ToJObject()["messageChain"]?.ToString()!);
                            var chain = new List<MessageBase>();
                            
                            foreach (var token in arr)
                            {
                                chain.Add(token.ToString().ToConcreteMessage());
                            }

                            re.MessageChain = chain;

                            Console.WriteLine(re.MessageChain.ToJson());
                            
                            module.Execute(re);
                        }
                    }
                }
                else
                {
                    MatchBotMessageEvents(args.Data);
                    MatchGroupEvents(args.Data);
                    MatchApplyEvents(args.Data);
                    MatchBotEvents(args.Data);
                }
            };
            
            _webSocket.Connect();
        }

        public static async Task Terminate()
        {
            _webSocket.Close();
            
            await Session.Disconnect();
        }

        public static async Task<string> GetPluginVersion()
        {
            var result = (await HttpUtility.Get($"{Session.GetUrl()}/about")).Content.ToJObject();

            if (result.GetPropertyValue("code") != "0")
            {
                throw new Exception(result.GetPropertyValue("errorMessage"));
            }

            return result["data"].GetPropertyValue("version");
        }

        public static async Task HandleGroupJoinRequest(MemberJoinApplyEventArgs args, MemberJoinApplyOperateType operateType, string responseMessage = "")
        {
            await HttpUtility.Post($"{Session.GetUrl()}/resp/memberJoinRequestEvent", new
            {
                sessionKey = Session.SessionKey,
                eventId = args.EventId,
                fromId = args.FromId,
                groupId = args.GroupId,
                operate = operateType,
                message = responseMessage
            }.ToJson());
        }

        public static async Task HandleInvitedRequest(BotInvitedEventArgs args, bool accept, string responseMessage = "")
        {
            var re = await HttpUtility.Post($"{Session.GetUrl()}/resp/botInvitedJoinGroupRequestEvent", new
            {
                sessionKey = Session.SessionKey,
                eventId = args.EventId,
                fromId = args.FromId,
                groupId = args.GroupId,
                operate = accept ? 0 : 1,
                message = responseMessage
            }.ToJson());
        }

        public static async Task<IEnumerable<BotFriend>> GetFriendList()
        {
            var result = await HttpUtility.Get($"{Session.GetUrl()}//friendList?sessionKey={Session.SessionKey}");

            return JArray.Parse(result.Content).ToObject<IEnumerable<BotFriend>>();
        }
        
        public static async Task<IEnumerable<BotGroup>> GetGroupList()
        {
            var result = await HttpUtility.Get($"{Session.GetUrl()}//groupList?sessionKey={Session.SessionKey}");

            return JArray.Parse(result.Content).ToObject<IEnumerable<BotGroup>>();
        }

        public static async Task<IEnumerable<GroupMember>> GetGroupMemberList(string target)
        {
            var result = await HttpUtility.Get($"{Session.GetUrl()}//memberList?sessionKey={Session.SessionKey}&target={target}");

            return JArray.Parse(result.Content).ToObject<IEnumerable<GroupMember>>();
        }
    }
}