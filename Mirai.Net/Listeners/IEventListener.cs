using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data.Events;

namespace Mirai.Net.Listeners
{
    public interface IEventListener
    {
        public IEnumerable<EventType> EventTypes { get; init; }

        public void Execute(EventArgsBase args);
    }
}