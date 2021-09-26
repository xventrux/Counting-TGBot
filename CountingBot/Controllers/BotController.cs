using CountingBot.AppServices.Services.CommandService;
using CountingBot.AppServices.Services.UpdateService;
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
        private readonly IUpdateService updateService;

        public BotController(ITelegramBotClient telegramBotClient, 
            ICommandService commandService, 
            IUpdateService updateService)
        {
            this.telegramBotClient = telegramBotClient;
            this.commandService = commandService;
            this.updateService = updateService;
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

            return Ok();
        }
    }
}
