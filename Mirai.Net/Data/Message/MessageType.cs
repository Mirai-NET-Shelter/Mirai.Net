using System.Runtime.Serialization;

namespace Mirai.Net.Data.Message
{
    public enum MessageType
    {
        Source,
        Quote,
        At,
        AtAll,
        Face,
        Plain,
        Image,
        FlashImage,
        Voice,
        Xml,
        Json,
        App,
        Poke,
        Dice,
        MusicShare,
        Forward,
        File
    }
}