using System;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Exceptions;

[Serializable]
public class InvalidCommandEntityException : Exception
{
    //
    // For guidelines regarding the creation of new exception types, see
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    // and
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    //

    public InvalidCommandEntityException()
    {
    }

    public InvalidCommandEntityException(string message) : base(message)
    {
    }

    public InvalidCommandEntityException(string message, Exception inner) : base(message, inner)
    {
    }

    protected InvalidCommandEntityException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}