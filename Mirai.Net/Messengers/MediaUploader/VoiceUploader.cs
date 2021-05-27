using System;
using System.IO;
using System.Threading.Tasks;
using Mirai.Net.Data.Messengers.Enums;
using Mirai.Net.Data.Messengers.Media;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net.Messengers.MediaUploader
{
    public class VoiceUploader
    {
        public static async Task<VoiceUploadCallback> Upload(byte[] file, ImageUploaderType type = ImageUploaderType.Group)
        {
            //目前仅支持group
            var requestType = "group";
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/uploadVoice",
                file, new
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
                            value = requestType
                        },
                    },
                    fileName = "voice"
                }.ToJson());

            return result.Content.ToObject<VoiceUploadCallback>();
        }
        
        public static async Task<VoiceUploadCallback> Upload(string filePath, ImageUploaderType type = ImageUploaderType.Group)
        {
            return await Upload(await File.ReadAllBytesAsync(filePath), type);
        }
    }
}