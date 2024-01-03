using System;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Exceptions;

/// <summary>
///     地址错误异常
/// </summary>
[Serializable]
public class InvalidAddressException : Exception
{
    //
    // For guidelines regarding the creation of new exception types, see
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    // and
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    //

    internal InvalidAddressException()
    {
    }

    internal InvalidAddressException(string message) : base(message)
    {
    }

    internal InvalidAddressException(string message, Exception inner) : base(message, inner)
    {
    }

    internal InvalidAddressException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}