using Flurl.Http;
using Manganese.Text;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils.Internal;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using File = Mirai.Net.Data.Shared.File;

namespace Mirai.Net.Sessions.Http.Managers;

/// <summary>
/// 文件管理器
/// </summary>
public static class FileManager
{
    /// <summary>
    ///     获取群文件列表
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="withDownloadInfo">附带下载信息，默认不附带</param>
    /// <param name="folderId">文件夹id，空字符串即为根目录</param>
    /// <returns></returns>
    public static async Task<IEnumerable<File>> GetFilesAsync(string groupId, bool? withDownloadInfo = null,
        string folderId = "")
    {
        var result = await HttpEndpoints.FileList.GetAsync(new
        {
            target = groupId,
            withDownloadInfo,
            id = folderId
        });

        var arr = result.Fetch("data").ToJArray();

        return arr.Select(x => x.ToObject<File>());
    }

    /// <summary>
    ///     获取群文件信息
    /// </summary>
    /// <param name="groupId">群号</param>
    /// <param name="fileId">文件id</param>
    /// <param name="withDownloadInfo"></param>
    /// <returns></returns>
    public static async Task<File> GetFileAsync(string groupId, string fileId, bool? withDownloadInfo = null)
    {
        var result = await HttpEndpoints.FileInfo.GetAsync(new
        {
            target = groupId,
            id = fileId,
            withDownloadInfo
        });

        return result.FetchJToken("data").ToObject<File>();
    }

    /// <summary>
    ///     创建群文件夹
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static async Task<File> CreateFolderAsync(string groupId, string name)
    {
        var result = await HttpEndpoints.FileCreate.PostJsonAsync(new
        {
            id = "",
            target = groupId,
            directoryName = name
        });

        return result.FetchJToken("data").ToObject<File>();
    }

    /// <summary>
    ///     删除群文件
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="fileId"></param>
    public static async Task DeleteFileAsync(string groupId, string fileId)
    {
        _ = await HttpEndpoints.FileDelete.PostJsonAsync(new
        {
            target = groupId,
            id = fileId
        });
    }

    /// <summary>
    ///     移动群文件
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="fileId">移动文件id</param>
    /// <param name="destination">移动目标文件夹id</param>
    public static async Task MoveFileAsync(string groupId, string fileId, string destination)
    {
        _ = await HttpEndpoints.FileMove.PostJsonAsync(new
        {
            target = groupId,
            id = fileId,
            movoTo = destination
        });
    }

    /// <summary>
    ///     重命名群文件
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="fileId">重命名文件id</param>
    /// <param name="newName">新文件名</param>
    public static async Task RenameFileAsync(string groupId, string fileId, string newName)
    {
        _ = await HttpEndpoints.FileRename.PostJsonAsync(new
        {
            target = groupId,
            id = fileId,
            renameTo = newName
        });
    }

    /// <summary>
    ///     上传群文件，修复 https://github.com/SinoAHpx/Mirai.Net/issues/72 中提到的编码错误
    /// </summary>
    /// <param name="groupId">上传到哪个群</param>
    /// <param name="filePath">文件的路径</param>
    /// <param name="uploadPath">上传路径，例如/xx</param>
    /// <param name="fileName">上传的文件名</param>
    /// <returns>有几率返回null，这是个mirai-api-http的玄学问题</returns>
    public static async Task<File> UploadFileAsync(string groupId, string filePath, string uploadPath = "/", string fileName = null)
    {
        fileName ??= Path.GetFileName(filePath);

        var url = $"http://{MiraiBot.Instance.Address.HttpAddress}/{HttpEndpoints.FileUpload.GetDescription()}";

        using var fileStream = System.IO.File.Open(filePath, FileMode.Open);
        var streamContent = new StreamContent(fileStream);
        var hackedFileName = new string(Encoding.UTF8.GetBytes(fileName).Select(b => (char)b).ToArray());
        streamContent.Headers.Add("Content-Disposition", $@"form-data; name=""file""; filename=""{hackedFileName}""; filename*=""{hackedFileName}""");

        var response = await url
            .PostAsync(new MultipartFormDataContent
            {
                { new StringContent(MiraiBot.Instance.HttpSessionKey), "sessionKey" },
                { new StringContent("group"), "type" },
                { new StringContent(groupId), "target" },
                { new StringContent(uploadPath), "path" },
                { streamContent, "file", fileName }
            })
            .ReceiveString();


        response.EnsureSuccess("这大抵是个玄学问题罢。");

        var re = response.ToJObject();

        return !re.ContainsKey("name") ? null : re.ToObject<File>();
    }

    /// <summary>
    ///     上传图片
    /// </summary>
    /// <param name="imagePath">图片路径</param>
    /// <param name="imageUploadTargets">上传类型</param>
    /// <returns>item1: 图片id，item2：图片url</returns>
    public static async Task<(string, string)> UploadImageAsync(string imagePath,
        ImageUploadTargets imageUploadTargets = ImageUploadTargets.Group)
    {
        var url = $"http://{MiraiBot.Instance.Address.HttpAddress}/{HttpEndpoints.UploadImage.GetDescription()}";

        var result = await url
            .WithHeader("Authorization", $"session {MiraiBot.Instance.HttpSessionKey}")
            .PostMultipartAsync(x => x
                .AddString("type", imageUploadTargets.GetDescription())
                .AddFile("img", imagePath));

        var re = await result.GetStringAsync();
        re.EnsureSuccess("这大抵是个玄学问题罢。");

        return (re.Fetch("imageId"), re.Fetch("url"));
    }

    /// <summary>
    ///     上传语音
    /// </summary>
    /// <param name="voicePath">语言路径</param>
    /// <returns>item1: 语音id，item2：语音url</returns>
    public static async Task<(string, string)> UploadVoiceAsync(string voicePath)
    {
        var url = $"http://{MiraiBot.Instance.Address.HttpAddress}/{HttpEndpoints.UploadVoice.GetDescription()}";

        var result = await url
            .WithHeader("Authorization", $"session {MiraiBot.Instance.HttpSessionKey}")
            .PostMultipartAsync(x => x
                .AddString("type", "group")
                .AddFile("voice", voicePath));

        var re = await result.GetStringAsync();
        re.EnsureSuccess("这大抵是个玄学问题罢。");

        return (re.Fetch("voiceId"), re.Fetch("url"));
    }
}