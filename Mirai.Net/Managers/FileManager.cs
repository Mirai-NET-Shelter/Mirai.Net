using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mirai.Net.Data.Files;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Managers
{
    [Obsolete("BUGGGGGG")]
    public class FileManager
    {
        private readonly MiraiBot _bot;

        public FileManager(MiraiBot bot)
        {
            _bot = bot;
        }

        public async Task<IEnumerable<File>> GetFiles(string target)
        {
            var response = await _bot.Get("file/list", new[]
            {
                ("id", ""),
                ("target", target)
            });
            var arr = response.ToJObject().Fetch("data").ToJArray();
            
            return arr.Select(x => x.ToObject<File>());
        } 
    }
}