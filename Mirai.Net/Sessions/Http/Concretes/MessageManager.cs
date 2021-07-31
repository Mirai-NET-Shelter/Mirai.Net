using Mirai.Net.Data.Messages;

namespace Mirai.Net.Sessions.Http.Concretes
{
    public class MessageManager
    {
        public readonly MiraiBot Bot;

        public MessageManager(MiraiBot bot)
        {
            Bot = bot;
        }

        public string SendFriendMessage(string target)
        {
            return "";
        }
    }
}