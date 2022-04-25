using System;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Exceptions;

/// <summary>
/// 
/// </summary>
[Serializable]
public class InvalidWebsocketReponseException : Exception
{
    //
    // For guidelines regarding the creation of new exception types, see
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    // and
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    //

    /// <summary>
    /// 
    /// </summary>
    public InvalidWebsocketReponseException()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public InvalidWebsocketReponseException(string message) : base(message)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="inner"></param>
    public InvalidWebsocketReponseException(string message, Exception inner) : base(message, inner)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected InvalidWebsocketReponseException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}