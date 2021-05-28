using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static class Bot
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
        
        public static async Task Launch()
        {
            await Session.Connect();
        }

        public static async Task Terminate()
        {
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