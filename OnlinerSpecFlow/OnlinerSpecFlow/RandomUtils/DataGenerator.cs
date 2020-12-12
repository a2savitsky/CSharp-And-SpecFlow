using System;

namespace OnlinerSpecFlow.RandomUtils
{
    static class DataGenerator
    {
        public static int GetRandomNumber(int maxValue, int minValue = 0)
        {
            var rnd = new Random();
            return rnd.Next(minValue: minValue, maxValue: maxValue);
        }
    }
}
