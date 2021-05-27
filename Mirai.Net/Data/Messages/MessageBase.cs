using System.Collections.Generic;

namespace Mirai.Net.Data.Messages
{
    public abstract class MessageBase
    {
        public abstract string Type { get; set; }

        public virtual string Id { get; set; }
        public virtual string Time { get; set; }
        public virtual string GroupId { get; set; }
        public virtual string SenderId { get; set; }
        public virtual string TargetId { get; set; }
        public virtual IEnumerable<MessageBase> Origin { get; set; }
        public virtual string Target { get; set; }
        public virtual string Display { get; set; }
        public virtual string FaceId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Test { get; set; }
        public virtual string ImageId { get; set; }
        public virtual string Url { get; set; }
        public virtual string Path { get; set; }
        public virtual string VoiceId { get; set; }
        public virtual string Xml { get; set; }
        public virtual string Json { get; set; }
        public virtual string App { get; set; }
        public virtual string Title { get; set; }
        public virtual string Brief { get; set; }
        public virtual string Source { get; set; }
        public virtual string Summary { get; set; }
        public virtual IEnumerable<Node> NodeList { get; set; }
        public virtual string InternalId { get; set; }
        public virtual string Size { get; set; }
        public virtual string Kind { get; set; }
        public virtual string JumpUrl { get; set; }
        public virtual string PictureUrl { get; set; }
        public virtual string MusicUrl { get; set; }
        
        public class Node
        {
            public string SenderId { get; set; }
            public string Time { get; set; }
            public string SenderName { get; set; }
            public IEnumerable<MessageBase> MessageChain { get; set; }
        }
    }
}