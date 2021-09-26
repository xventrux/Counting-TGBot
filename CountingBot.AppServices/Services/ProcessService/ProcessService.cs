using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingBot.AppServices.Services.ProcessService
{
    public class ProcessService : IProcessService
    {
        public readonly List<TelegramProcess> processes;

        public ProcessService()
        {
            processes = new List<TelegramProcess>()
            {
                //Сюда нужно добавить существующие команды
            };
        }

        public List<TelegramProcess> GetProcesses() => processes;
    }
}
