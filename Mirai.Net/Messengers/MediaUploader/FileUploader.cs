using System;
using System.Threading.Tasks;
using Mirai.Net.Data.Messengers.Media;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net.Messengers.MediaUploader
{
    [Obsolete("鉴于此部分的文档编写的过于迷惘，如果你知道path参数该怎么用的话或许可以试试使用这个类")]
    public class FileUploader
    {
        public static async Task<FileUploadCallback> Upload(string target, byte[] file, string uploadPath)
        {
            var url = $"{Bot.Session.GetUrl()}/uploadFileAndSend";
            var result = await HttpUtility.Post(url, file, GetJson(target, uploadPath));

            return result.Content.ToObject<FileUploadCallback>();
        }
        
        public static async Task<FileUploadCallback> Upload(string target, string file, string uploadPath)
        {
            var url = $"{Bot.Session.GetUrl()}/uploadFileAndSend";
            var result = await HttpUtility.Post(url, file, GetJson(target, uploadPath));

            return result.Content.ToObject<FileUploadCallback>();
        }

        private static string GetJson(string target, string uploadPath)
        {
            return new
            {
                parameters = new[]
                {
                    new
                    {
                        key = "sessionKey",
                        value = Bot.Session.SessionKey
                    },
                    new
                    {
                        key = "type",
                        value = "Group"
                    },
                    new
                    {
                        key = "target",
                        value = target
                    },
                    new
                    {
                        key = "path",
                        value = uploadPath
                    }
                },
                fileName = "file"
            }.ToJson();
        }
    }
}