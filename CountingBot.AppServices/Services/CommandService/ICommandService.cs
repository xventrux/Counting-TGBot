using CountingBot.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingBot.AppServices.Services.CommandService
{
    /// <summary>
    /// Сервис для работы с командами
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// Возвращает список команд
        /// </summary>
        /// <returns></returns>
        List<TelegramCommand> GetCommands();
    }
}
