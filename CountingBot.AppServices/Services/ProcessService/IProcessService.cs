using CountingBot.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingBot.AppServices.Services.ProcessService
{
    /// <summary>
    /// Сервис для работы с процессом
    /// </summary>
    public interface IProcessService
    {
        List<TelegramProcess> GetProcesses();
    }
}
