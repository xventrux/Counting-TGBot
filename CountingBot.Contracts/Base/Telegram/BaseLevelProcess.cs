using CountingBot.Domain.Entities;
using CountingBot.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CountingBot.Contracts.Base.Telegram
{
    public abstract class BaseLevelProcess : TelegramProcess
    {
        public abstract int UserLevel { get; }
        public override async Task<User> Execute(User user, TelegramMessage msg, ITelegramBotClient client)
        {
            if(user.Step > 0)
            {
                return await Do(user, msg, client);
            }
            else
            {
                if(user.Level >= UserLevel)
                {
                    return await Do(user, msg, client);
                }
                else
                {
                    await client.SendTextMessageAsync(user.Id, "У вас недостаточный уровень");
                    return user;
                }
            }
        }

        protected abstract Task<User> Do(User user, TelegramMessage msg, ITelegramBotClient client);
    }
}
