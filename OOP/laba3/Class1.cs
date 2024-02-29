using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace laba3
{
    static class StaticOperation
    {
        static int b;
        public static void Summ(Set set)
        {
            foreach (var a in set)
            {
                b += Convert.ToInt32(a);
            }
            Console.WriteLine("Сумма класса:" + b);
        }
        static public int maxmin(Set set)
        {
            int max = 0;
            int min = 999;
            foreach (int a in set)
            {
                if (a > max)
                {
                    max = a;
                }
                if (a < min)
                {
                    min = a;
                }

            }
            return max - min;
        }
        static public int length(Set set)
        {
            int count = 0;
            foreach (var a in set)
            {
                count++;
            }
            return count;
        }
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }

    }
}
