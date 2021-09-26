using CountingBot.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingBot.AppServices.Services.CommandService
{
    /// <inheritdoc/>
    public class CommandService : ICommandService
    {
        /// <summary>
        /// Список команд
        /// </summary>
        private readonly List<TelegramCommand> commands;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CommandService()
        {
            commands = new List<TelegramCommand>()
            {
                //Сюда нужно добавить существующие команды
            };
        }

        /// <inheritdoc/>
        public List<TelegramCommand> GetCommands() => commands;
    }
}
