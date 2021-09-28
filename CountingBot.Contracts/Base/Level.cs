using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingBot.Contracts.Base
{
    /// <summary>
    /// Уровень
    /// </summary>
    public abstract class Level
    {
        /// <summary>
        /// Наименование уровня
        /// </summary>
        public readonly string Name;


        /// <summary>
        /// Теория по уровню
        /// </summary>
        public readonly string  Theory;


        /// <summary>
        /// Уровень пользователя
        /// </summary>
        public readonly int UserLevel;


        /// <summary>
        /// Количество опыта за задание из уровня
        /// </summary>
        public readonly int Exp;

        protected Level(string name, string theory, int userLevel, int exp)
        {
            Name = name;
            Theory = theory;
            UserLevel = userLevel;
            Exp = exp;
        }


        /// <summary>
        /// Возвращает задание уровня
        /// </summary>
        /// <returns></returns>
        public abstract void CreateProblem();
    }
}
