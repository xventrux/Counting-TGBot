using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingBot.Domain.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public long Id { get; set; }


        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// Уровень пользователя
        /// </summary>
        public int Level { get; set; }


        /// <summary>
        /// Опыт пользователя
        /// </summary>
        public int Exp { get; set; }


        //Процесс в контексте нашей программы - это
        //набор последовательных сообщений бота пользователю
        //с возможным изменением данных пользователя
        #region Процесс
        /// <summary>
        /// Наименование текущего процесса пользователя
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// Шаг процесса пользователя
        /// </summary>
        public int Step { get; set; }
        #endregion
    }
}
