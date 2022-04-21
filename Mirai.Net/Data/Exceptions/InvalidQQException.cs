using System;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Exceptions;

/// <summary>
///     错误的QQ号
/// </summary>
[Serializable]
public class InvalidQQException : Exception
{
    //
    // For guidelines regarding the creation of new exception types, see
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    // and
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    //

    internal InvalidQQException()
    {
    }

    internal InvalidQQException(string message) : base(message)
    {
    }

    internal InvalidQQException(string message, Exception inner) : base(message, inner)
    {
    }

    internal InvalidQQException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}