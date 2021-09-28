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

namespace CountingBot.Contracts.Processes
{
    public class ProcessL1 : BaseLevelProcess
    {
        public override int UserLevel => 0;
        public override string Name => "l1";

        protected override async Task<User> Do(User user, TelegramMessage msg, ITelegramBotClient client)
        {
            if (user.Step == 0)
            {
                await client.SendTextMessageAsync(user.Id, "Добро пожаловать на первый уровень");
                user.ClearProcess();
            }

            return user;
        }
    }
}
