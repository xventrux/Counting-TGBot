using CountingBot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CountingBot.Contracts.Base
{
    /// <summary>
    /// Телеграм команда
    /// </summary>
    public abstract class TelegramCommand
    {
        /// <summary>
        /// Наименование команды
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Абстрактный метод, который выполняет команду
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="msg">Сообщение</param>
        /// <param name="client">Телеграм клиент</param>
        /// <returns></returns>
        public abstract Task<User> Execute(User user, TelegramMessage msg, ITelegramBotClient client);
        /// <summary>
        /// Метод, проверяющий текст из параметра на совпадение с именем команды
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool Contains(string msg)
        {
            return msg.ToLower().Contains(Name.ToLower());
        }
    }
}
