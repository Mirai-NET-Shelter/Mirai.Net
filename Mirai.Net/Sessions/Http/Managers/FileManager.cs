using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;

namespace Mirai.Net.Sessions.Http.Managers
{
    public static class FileManager
    {
        /// <summary>
        /// 获取群文件列表
        /// </summary>
        /// <param name="target"></param>
        /// <param name="withDownloadInfo">附带下载信息，默认不附带</param>
        /// <param name="folderId">文件夹id，空字符串即为根目录</param>
        /// <returns></returns>
        [Obsolete("此方法因为mirai-api-http的缺陷，存在严重性能问题（只能获取少量群文件）。")]
        public static async Task<IEnumerable<File>> GetFilesAsync(string target, bool? withDownloadInfo = null, string folderId = "")
        {
            var result = await HttpEndpoints.FileList.GetAsync(new
            {
                target,
                withDownloadInfo,
                id = folderId
            });

            var arr = result.Fetch("data").ToJArray();

            return arr.Select(x => x.ToObject<File>());
        }

        /// <summary>
        /// 获取群文件信息
        /// </summary>
        /// <param name="target">群号</param>
        /// <param name="fileId">文件id</param>
        /// <param name="withDownloadInfo"></param>
        /// <returns></returns>
        public static async Task<File> GetFileAsync(string target, string fileId, bool? withDownloadInfo = null)
        {
            var result = await HttpEndpoints.FileInfo.GetAsync(new
            {
                target,
                id = fileId,
                withDownloadInfo
            });

            return result.FetchJToken("data").ToObject<File>();
        }
    }
}