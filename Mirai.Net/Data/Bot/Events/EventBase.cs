using System;

namespace Mirai.Net.Data.Bot.Events
{
    public class EventBase
    {
        public virtual event EventHandler<EventArgsBase> Event;

        protected EventBase()
        {
        }
    }
}