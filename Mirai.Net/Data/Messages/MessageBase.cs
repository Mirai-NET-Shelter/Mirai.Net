using System.Collections.Generic;

namespace Mirai.Net.Data.Messages
{
    //TODO: add comment for concrete types
    public abstract class MessageBase
    {
        /// <summary>
        /// 类型
        /// </summary>
        public abstract string Type { get; set; }

        protected virtual string Id { get; set; }
        protected virtual string Time { get; set; }
        protected virtual string GroupId { get; set; }
        protected virtual string SenderId { get; set; }
        protected virtual string TargetId { get; set; }
        protected virtual IEnumerable<MessageBase> Origin { get; set; }
        protected virtual string Target { get; set; }
        protected virtual string Display { get; set; }
        protected virtual string FaceId { get; set; }
        protected virtual string Name { get; set; }
        protected virtual string Test { get; set; }
        protected virtual string ImageId { get; set; }
        protected virtual string Url { get; set; }
        protected virtual string Path { get; set; }
        protected virtual string VoiceId { get; set; }
        protected virtual string Xml { get; set; }
        protected virtual string Json { get; set; }
        protected virtual string App { get; set; }
        protected virtual string Title { get; set; }
        protected virtual string Brief { get; set; }
        protected virtual string Source { get; set; }
        protected virtual string Summary { get; set; }
        protected virtual IEnumerable<Node> NodeList { get; set; }
        protected virtual string InternalId { get; set; }
        protected virtual string Size { get; set; }
        protected virtual string Kind { get; set; }
        protected virtual string JumpUrl { get; set; }
        protected virtual string PictureUrl { get; set; }
        protected virtual string MusicUrl { get; set; }
        
        public class Node
        {
            protected string SenderId { get; set; }
            protected string Time { get; set; }
            protected string SenderName { get; set; }
            protected IEnumerable<MessageBase> MessageChain { get; set; }
        }
    }
}