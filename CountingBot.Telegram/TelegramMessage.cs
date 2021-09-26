using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingBot.Telegram
{
    /// <summary>
    /// Телеграм сообщение
    /// </summary>
    public class TelegramMessage
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Username пользователя
        /// </summary>
        public string Login { get; set; }
    }
}
