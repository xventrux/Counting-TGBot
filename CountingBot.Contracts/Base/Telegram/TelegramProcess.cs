using CountingBot.Domain.Entities;
using CountingBot.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CountingBot.Contracts.Base
{
    public abstract class TelegramProcess
    {
        public abstract string Name { get; }
        public abstract Task<User> Execute(User user, TelegramMessage msg, ITelegramBotClient client);
        public bool Contains(string name)
        {
            return name.ToLower().Contains(Name.ToLower());
        }
    }
}
