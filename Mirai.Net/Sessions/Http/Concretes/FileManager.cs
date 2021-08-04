using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Utils.Extensions.Managers;
using Newtonsoft.Json;
using File = Mirai.Net.Data.Shared.File;

namespace Mirai.Net.Sessions.Http.Concretes
{
    public class FileManager
    {
        public readonly MiraiBot Bot = MiraiBotFactory.Bot;
        
        /// <summary>
        ///     获取群文件列表,
        ///     性能很差, 如果群文件很多的话会卡住
        /// </summary>
        /// <param name="group"></param>
        /// <param name="id">文件id, 默认为空字符串, 空字符串就是根目录</param>
        /// <returns></returns>
        public async Task<IEnumerable<File>> GetFiles(string group, string id = "")
        {
            var response = await this.SendGet(HttpEndpoints.FileList, group, id);

            return response.ToJArray().Select(x => x.ToObject<File>());
        }

        /// <summary>
        ///     获取文件信息
        /// </summary>
        /// <param name="group"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<File> GetFile(string group, string id)
        {
            var response = await this.SendGet(HttpEndpoints.FileInfo, group, id);

            return JsonConvert.DeserializeObject<File>(response);
        }

        /// <summary>
        ///     请关注https://github.com/project-mirai/mirai-api-http/issues/428
        /// </summary>
        /// <param name="name"></param>
        /// <param name="group"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [Obsolete("不知道是因为什么玄学用不了")]
        public async Task<File> CreateDirectory(string group, string name, string parentId = "")
        {
            var payload = new
            {
                id = parentId,
                directoryName = name,
                group
            };

            var response = await Bot.PostHttp(HttpEndpoints.FileCreate, payload);

            return JsonConvert.DeserializeObject<File>(response);
        }

        /// <summary>
        ///     上传文件
        /// </summary>
        /// <param name="group"></param>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        [Obsolete("不知道是因为什么玄学用不了你知道么这个接口的文档甚至没有给出上传到哪个群的参数所以这个方法的第一个参数居然没有被用到")]
        public async Task<File> UploadFile(string group, FileInfo file, string path = "")
        {
            var response = await Bot.PostFileHttp(HttpEndpoints.FileUpload, file,
                "file",
                true,
                ("type", "group"), ("path", path));

            return JsonConvert.DeserializeObject<File>(response);
        }

        /// <summary>
        ///     上传图片
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="targets"></param>
        /// <returns>
        ///     <para>Item1: 图片id</para>
        ///     <para>Item2: 图片的url</para>
        /// </returns>
        public async Task<(string, string)> UploadImage(FileInfo fileInfo,
            ImageUploadTargets targets = ImageUploadTargets.Group)
        {
            var response = await Bot.PostFileHttp(HttpEndpoints.UploadImage, fileInfo, "img", true,
                ("type", targets.GetDescription()));

            var json = response.ToJObject();

            return (json.Fetch("imageId"), json.Fetch("url"));
        }

        /// <summary>
        ///     上传语音
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="targets"></param>
        /// <returns>
        ///     <para>Item1: 语音id</para>
        ///     <para>Item2: 语音的url</para>
        /// </returns>
        public async Task<(string, string)> UploadVoice(FileInfo fileInfo)
        {
            var response = await Bot.PostFileHttp(HttpEndpoints.UploadVoice, fileInfo, "voice", true,
                ("type", "group"));

            var json = response.ToJObject();

            return (json.Fetch("voiceId"), json.Fetch("url"));
        }
    }
}