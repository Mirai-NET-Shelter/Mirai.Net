using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net
{
    public static partial class Bot
    {
        private static void MatchApplyEvents(string data)
        {
            switch (data.ToJObject().GetPropertyValue("type"))
            {
                
            }
        }
    }
}