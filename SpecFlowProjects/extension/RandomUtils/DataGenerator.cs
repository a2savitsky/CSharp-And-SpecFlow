using System;
using System.Linq;

namespace extension.RandomUtils
{
    public static class DataGenerator
    {
        public static int GetRandomNumber(int maxValue, int minValue = 0)
        {
            var rnd = new Random();
            return rnd.Next(minValue: minValue, maxValue: maxValue);
        }

        public static string GetRandomString(int sizeOfString = 10)
        {
            var rnd = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, sizeOfString)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
