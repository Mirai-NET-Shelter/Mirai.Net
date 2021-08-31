using System;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Exceptions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Utils;

namespace Mirai.Net.Sessions
{
    /// <summary>
    /// mirai-api-http机器人描述
    /// </summary>
    public class MiraiBot : IDisposable
    {
        #region Properties

        /// <summary>
        /// 最后一个启动的MiraiBot实例
        /// </summary>
        internal static MiraiBot Instance { get; set; }
        
        internal string HttpSessionKey { get; set; }

        private string _address;
        private string _qq;

        /// <summary>
        /// mirai-api-http本地服务器地址，比如：localhost:114514
        /// <exception cref="InvalidAddressException">传入错误的地址将会抛出异常</exception>
        /// </summary>
        public string Address
        {
            get => _address.TrimEnd('/').Empty("http://").Empty("https://");
            set
            {
                if (!value.Contains(":")) throw new InvalidAddressException($"错误的地址: {value}");

                var split = value.Split(':');

                if (split.Length != 2) throw new InvalidAddressException($"错误的地址: {value}");
                if (!split.Last().IsInteger()) throw new InvalidAddressException($"错误的地址: {value}");

                _address = value;
            }
        }

        /// <summary>
        /// 建立连接的QQ账号
        /// </summary>
        public string QQ
        {
            get => _qq;
            set => _qq = value.IsIntegerOrThrow(new InvalidQQException("错误的QQ号"));
        }

        /// <summary>
        /// Mirai.Net总是需要一个VerifyKey
        /// </summary>
        public string VerifyKey { get; set; }
        
        #endregion
        
        #region Exposed

        public async Task LaunchAsync()
        {
            Instance = this;
            
            await VerifyAsync();
            await BindAsync();
        }

        #endregion
        
        #region Http adapter private helpers

        /// <summary>
        /// 发送验证请求，获得未激活的session key
        /// </summary>
        /// <returns></returns>
        private async Task VerifyAsync()
        {
            var result = await HttpEndpoints.Verify.PostJsonAsync(new
            {
                verifyKey = VerifyKey
            }, false);

            result.EnsureSuccess();

            HttpSessionKey = result.Fetch("session");
        }

        /// <summary>
        /// 激活session key
        /// </summary>
        private async Task BindAsync()
        {
            var result = await HttpEndpoints.Bind.PostJsonAsync(new
            {
                sessionKey = HttpSessionKey,
                qq = QQ
            }, false);

            result.EnsureSuccess();
        }

        /// <summary>
        /// 释放已激活的session
        /// </summary>
        private async Task ReleaseAsync()
        {
            var result = await HttpEndpoints.Release.PostJsonAsync(new
            {
                sessionKey = HttpSessionKey,
                qq = QQ
            }, false);

            result.EnsureSuccess();
        }

        #endregion

        public async void Dispose()
        {
            await ReleaseAsync();
        }
    }
}