using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingBot.Contracts.Base
{
    /// <summary>
    /// Арифметическая задача
    /// </summary>
    public abstract class BaseProblem
    {
        /// <summary>
        /// Ответ
        /// </summary>
        public int Answer { get; set; }

        /// <summary>
        /// Варинаты ответа
        /// </summary>
        public int[] Variants { get; set; }


        /// <summary>
        /// Создать задачу
        /// </summary>
        public abstract string CreateProblem();
    }
}
