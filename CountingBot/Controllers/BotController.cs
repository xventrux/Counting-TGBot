using CountingBot.AppServices.Services.CommandService;
using CountingBot.AppServices.Services.ProcessService;
using CountingBot.AppServices.Services.UpdateService;
using CountingBot.AppServices.Services.UserService;
using CountingBot.Telegram;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CountingBot.Controllers
{
    /// <summary>
    /// Контроллер для работы с ботом
    /// </summary>
    [ApiController]
    [Route("api/message/update")]
    public class BotController : ControllerBase
    {
        private readonly ITelegramBotClient telegramBotClient;
        private readonly ICommandService commandService;
        private readonly IProcessService processService;
        private readonly IUpdateService updateService;
        private readonly IUserService userService;

        public BotController(ITelegramBotClient telegramBotClient,
            ICommandService commandService,
            IUpdateService updateService,
            IProcessService processService, 
            IUserService userService)
        {
            this.telegramBotClient = telegramBotClient;
            this.commandService = commandService;
            this.updateService = updateService;
            this.processService = processService;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Started");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {

            await telegramBotClient.SetMyCommandsAsync(new List<BotCommand>()
            {
                new BotCommand() { Command = "/start", Description = "Показать список команд" }
            });

            //Если обновление пустое, то ничего не делаем
            if (update == null) return Ok();

            TelegramMessage message = updateService.Check(update);

            if (message == null) return Ok();

            Domain.Entities.User user = await userService.Login(message.Id);

            if(user == null)
            {
                user = await userService.Registration(message.Id, message.Login);
                await telegramBotClient.SendTextMessageAsync(user.Id, "Добро пожаловать. Я буду тренировать тебя быстро выполнять различные арифметические команды");
            }

            //Если у него есть какой-либо процесс, то запускаем его и больше ничего не делаем
            if (!String.IsNullOrEmpty(user.ProcessName))
            {
                foreach (var process in processService.GetProcesses())
                {
                    if (process.Contains(user.ProcessName))
                    {
                        user = await process.Execute(user, message, telegramBotClient);
                        await userService.Update(user);
                        return Ok();
                    }
                }
            }

            //Иначе смотрим какую команду он написал и выполняем ее
            foreach (var command in commandService.GetCommands())
            {
                if (command.Contains(message.Text))
                {
                    user = await command.Execute(user, message, telegramBotClient);
                    await userService.Update(user);
                    return Ok();
                }
            }

            //Если нет такой команды, то отправляем соответсвующие сообщение
            await telegramBotClient.SendTextMessageAsync(message.Id, "Я вас не понимаю");
            return Ok();
        }
    }
}
