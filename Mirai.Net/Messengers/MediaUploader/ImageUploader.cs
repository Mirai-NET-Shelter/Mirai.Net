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
        public async Task<ImageUploadCallback> Upload(string filePath, ImageUploaderType type = ImageUploaderType.Group)
        {
            var requestType = type switch
            {
                ImageUploaderType.Friend => "friend",
                ImageUploaderType.Group => "group",
                ImageUploaderType.Temp => "temp",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/uploadImage",
                filePath, new
                {
                    sessionKey = Bot.Session.SessionKey,
                    type = requestType
                }.ToJson());

            return result.Content.ToObject<ImageUploadCallback>();
        }
    }
}