using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;
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
                            module.Execute(args.Data.ToObject<MessageReceivedArgs>());
                        }
                    }
                }
                else
                {
                    MatchBotMessageEvents(args.Data);
                    MatchGroupEvents(args.Data);
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
    }
}