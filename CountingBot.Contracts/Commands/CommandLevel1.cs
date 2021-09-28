using CountingBot.Contracts.Base;
using CountingBot.Contracts.Base.Telegram;
using CountingBot.Domain.Entities;
using CountingBot.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CountingBot.Contracts.Commands
{
    public class CommandLevel1 : TelegramCommand
    {
        public override string Name => "/l1";

        public override string Description => "Умножение на 11";

        public override async Task<User> Execute(User user, TelegramMessage msg, ITelegramBotClient client)
        {
            user.ProcessName = "l1";
            return user;
        }
    }
}
