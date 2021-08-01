using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions.Managers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Sessions.Http.Concretes
{
    public class FileManager
    {
        public readonly MiraiBot Bot;

        public FileManager(MiraiBot bot)
        {
            Bot = bot;
        }

        /// <summary>
        /// 获取群文件列表
        /// </summary>
        /// <param name="group"></param>
        /// <param name="id">文件id, 默认为空字符串, 空字符串就是根目录</param>
        /// <returns></returns>
        public async Task<IEnumerable<File>> GetFiles(string group, string id = "")
        {
            var response = await this.SendGet(HttpEndpoints.FileList, group, id);

            return response.ToJArray().Select(x => x.ToObject<File>());
        }

        public async Task<File> GetFile(string group, string id)
        {
            var response = await this.SendGet(HttpEndpoints.FileInfo, group, id);

            return JsonConvert.DeserializeObject<File>(response);
        }
    }
}