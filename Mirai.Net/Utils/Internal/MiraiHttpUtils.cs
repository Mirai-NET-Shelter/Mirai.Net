using Flurl;
using Flurl.Http;
using Manganese.Text;
using Mirai.Net.Data.Exceptions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using NullValueHandling = Newtonsoft.Json.NullValueHandling;

namespace Mirai.Net.Utils.Internal;

/// <summary>
/// 用户自定义错误处理
/// </summary>
public delegate void ErrorHandler(Exception ex);
/// <summary>
/// 由于特定插件有自定义Endpoint的需求，因此有必要将PostJsonAsync与GetAsync整体暴露为public
/// </summary>
public static class MiraiHttpUtils
{
    /// <summary>
    /// 用户自定义错误处理器
    /// </summary>
    public static ErrorHandler HttpErrorHandler { get; set; }
    #region Guarantee

    /// <summary>
    ///     根据json判断这个json是否是正确的，否则抛出异常
    /// </summary>
    /// <param name="json"></param>
    /// <param name="appendix"></param>
    internal static void EnsureSuccess(this string json, string appendix = null)
    {
        var obj = json.ToJObject();

        var code = obj["code"]?.ToString();

        if (code is null or "0") return;

        var message = $"原因: {json.OfErrorMessage()}\r\n备注: ";
        message += string.IsNullOrEmpty(appendix)
            ? MiraiBot.Instance.ToJsonString()
            : appendix;

        var exception = new InvalidResponseException(message)
        {
            Data = {
                ["code"] = code,
                ["msg"] = obj.TryGetValue("msg", out var value) ? value.ToString() : null
            }
        };
        throw exception;
    }

    #endregion

    #region Http requests

    /// <summary>
    /// </summary>
    /// <param name="url"></param>
    /// <param name="withSessionKey">是否添加session头</param>
    /// <returns></returns>
    public static async Task<string> GetAsync(string url, bool withSessionKey = true)
    {
        try
        {
            var result = withSessionKey
                ? await url
                    .WithHeader("Authorization", $"session {MiraiBot.Instance.HttpSessionKey}")
                    .GetAsync()
                : await url.GetAsync();

            var re = await result.GetStringAsync();
            re.EnsureSuccess($"url={url}");

            return re;
        }
        catch (Exception e)
        {
            if (HttpErrorHandler != null)
            {
                e.Data["method"] = "get";
                e.Data["url"] = url;
                HttpErrorHandler.Invoke(e); // 如果错误处理器不为 null，则调用
            }

            else
                throw; // 否则，重新抛出异常
            return null;
        }
    }

    internal static async Task<string> GetAsync(this HttpEndpoints endpoints, object extra = null,
        bool withSessionKey = true)
    {
        var url = $"http://{MiraiBot.Instance.Address.HttpAddress}/{endpoints.GetDescription()}";

        if (extra != null)
            url = url.SetQueryParams(extra);

        return await GetAsync(url, withSessionKey);
    }

    /// <summary>
    /// </summary>
    /// <param name="url"></param>
    /// <param name="json"></param>
    /// <param name="withSessionKey">加入Authentication: session xxx 请求头</param>
    /// <returns></returns>
    public static async Task<string> PostJsonAsync(string url, object json, bool withSessionKey = true)
    {
        try
        {
            var result = withSessionKey
                ? await url
                    .WithHeader("Authorization", $"session {MiraiBot.Instance.HttpSessionKey}")
                    .PostStringAsync(json.ToJsonString(new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }))
                : await url.PostStringAsync(json.ToJsonString(new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }));

            var re = await result.GetStringAsync();
            re.EnsureSuccess($"url={url}\r\npayload={json.ToJsonString()}");

            return re;
        }
        catch (Exception e)
        {
            if (HttpErrorHandler != null)
            {
                e.Data["method"] = "post";
                e.Data["url"] = url;
                e.Data["json"] = json;
                HttpErrorHandler.Invoke(e); // 如果错误处理器不为 null，则调用
            }

            else
                throw; // 否则，重新抛出异常
            return null;
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="endpoint"></param>
    /// <param name="json"></param>
    /// <param name="withSessionKey">加入Authentication: session xxx 请求头</param>
    /// <returns></returns>
    internal static async Task<string> PostJsonAsync(this HttpEndpoints endpoint, object json,
        bool withSessionKey = true)
    {
        var url = $"http://{MiraiBot.Instance.Address.HttpAddress}/{endpoint.GetDescription()}";
        var result = await PostJsonAsync(url, json, withSessionKey);

        return result;
    }

    #endregion
}