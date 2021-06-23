using System.Collections.Generic;
using Mirai.Net.Data.Message;

namespace Mirai.Net.Listeners
{
    public interface IListener<T1, in T2>
    {
        public IEnumerable<T1> Executors { get; init; }

        public void Execute(T2 args);
    }
}