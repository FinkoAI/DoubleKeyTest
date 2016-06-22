using System;
using System.Linq;

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

        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
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

        /// <summary>
        /// Функция получения случайного числа
        /// </summary>
        /// <returns></returns>
        public static int RandomInt() 
        {
            return IntRandom.Next(1, 100);
        }
    }
}
