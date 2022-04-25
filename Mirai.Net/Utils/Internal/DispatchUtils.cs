using System;
using System.Threading.Tasks;
using System.Timers;

namespace Mirai.Net.Utils.Internal;

/// <summary>
/// 调度工具类
/// </summary>
public static class DispatchUtils
{
    /// <summary>
    /// 在等待指定的时间后执行异步操作
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="action"></param>
    public static void ExecuteScheduledActionAsync(TimeSpan duration, Func<Task> action)
    {
        Task.Run(async () =>
        {
            await Task.Delay(duration);
            await action();
        });
    }
    
    /// <summary>
    /// 在等待指定的时间后执行异步操作
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="action"></param>
    public static void ExecuteScheduledActionAsync(int duration, Func<Task> action)
    {
        ExecuteScheduledActionAsync(TimeSpan.FromMilliseconds(duration), action);
    }
    
    /// <summary>
    /// 在等待指定的事件后执行同步操作
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="action"></param>
    public static void ExecuteScheduledAction(TimeSpan duration, Action action)
    {
        Task.Run(async () =>
        {
            await Task.Delay(duration);
            action();
        });
    }

    /// <summary>
    /// 在等待指定的时间后执行同步操作
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="action"></param>
    public static void ExecuteScheduledAction(int duration, Action action)
    {
        ExecuteScheduledAction(TimeSpan.FromMilliseconds(duration), action);
    }
}