using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.UI.Helpers
{
    public static class RandomHelper
    {
        /// <summary>
        /// Символы для автогенерации строк
        /// </summary>
        const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        /// Генератор случайных чисел для автогенерации строк
        /// </summary>
        private static readonly Random StringRandom = new Random();

        private static readonly Random IntRandom = new Random();

        /// <summary>
        /// Функция получения случайной строки
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {

            return new string(Enumerable.Repeat(Chars, length)
              .Select(s => s[StringRandom.Next(s.Length)]).ToArray());
        }

        public static int RandomInt()
        {
            return IntRandom.Next(1, 100);
        }
    }
}
