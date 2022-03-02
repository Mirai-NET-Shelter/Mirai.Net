using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Shared;

/// <summary>
/// 文件
/// </summary>
public class File
{
    /// <summary>
    /// 文件名
    /// </summary>
    [JsonProperty("name")] public string Name { get; set; }

    /// <summary>
    /// 文件标识id
    /// </summary>
    [JsonProperty("id")] public string Id { get; set; }

    /// <summary>
    /// 文件路径
    /// </summary>
    [JsonProperty("path")] public string Path { get; set; }

    /// <summary>
    /// 父目录
    /// </summary>
    [JsonProperty("parent")] public File Parent { get; set; }

    /// <summary>
    /// 是不是文件
    /// </summary>
    [JsonProperty("isFile")] public bool IsFile { get; set; }

    /// <summary>
    /// 是不是母鹿
    /// </summary>
    [JsonProperty("isDirectory")] public bool IsDirectory { get; set; }

    /// <summary>
    /// 上传者
    /// </summary>
    [JsonProperty("contact")] public FileUploader Contact { get; set; }

    /// <summary>
    /// 下载信息
    /// </summary>
    [JsonProperty("downloadInfo")] public FileDownloadInfo DownloadInfo { get; set; }

    /// <summary>
    /// 文件上传者
    /// </summary>
    public class FileUploader
    {
        /// <summary>
        /// 上传者qq
        /// </summary>
        [JsonProperty("id")] public string Id { get; set; }

        /// <summary>
        /// 上传者昵称
        /// </summary>
        [JsonProperty("name")] public string Name { get; set; }

        /// <summary>
        /// 上传者在群内的权限
        /// </summary>
        [JsonProperty("permission")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions Permission { get; set; }
    }

    /// <summary>
    /// 文件下载信息
    /// </summary>
    public class FileDownloadInfo
    {
        /// <summary>
        /// sha1
        /// </summary>
        [JsonProperty("sha1")] public string Sha1 { get; set; }

        /// <summary>
        /// md5
        /// </summary>
        [JsonProperty("md5")] public string Md5 { get; set; }

        /// <summary>
        /// 下载链接
        /// </summary>
        [JsonProperty("url")] public string Url { get; set; }
        
        /// <summary>
        /// 下载次数
        /// </summary>
        [JsonProperty("downloadTimes")]
        public string DownloadTimes {get; set;}
        
        /// <summary>
        /// 上传者id
        /// </summary>
        [JsonProperty("uploaderId")]
        public string UploaderId {get; set;}
        
        /// <summary>
        /// 上传时间戳
        /// </summary>
        [JsonProperty("uploadTime")]
        public string UploadTime {get; set;}
        
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty("lastModifyTime")]
        public string LastModifyTime {get; set;}
    }
}
