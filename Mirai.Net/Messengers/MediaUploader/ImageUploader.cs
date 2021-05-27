using System;
using System.IO;
using System.Threading.Tasks;
using Mirai.Net.Data.Messengers.Enums;
using Mirai.Net.Data.Messengers.Media;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;
using RestSharp;

namespace Mirai.Net.Messengers.MediaUploader
{
    public class ImageUploader
    {
        public static async Task<ImageUploadCallback> Upload(byte[] file, ImageUploaderType type = ImageUploaderType.Group)
        {
            var requestType = type switch
            {
                ImageUploaderType.Friend => "friend",
                ImageUploaderType.Group => "group",
                ImageUploaderType.Temp => "temp",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/uploadImage",
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
                    fileName = "img"
                }.ToJson());

            return result.Content.ToObject<ImageUploadCallback>();
        }

        public static async Task<ImageUploadCallback> Upload(string filePath, ImageUploaderType type = ImageUploaderType.Group)
        {
            return await Upload(await File.ReadAllBytesAsync(filePath), type);
        }
    }
}