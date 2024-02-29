using System;
using System.Collections.Generic;
using System.Text;

namespace laba3
{
    static class Class2
    {
        public static void Sorter(this Set setEx, Set set2)
        {
            set2.items.Sort();
        }

        public static void CheckWord(this Set setEx, Set set3)
        {
            int d = int.MaxValue;
            foreach (string a in set3.words)
            {
                int size = a.Length;
                if (size < d)
                {
                    d = size;
                    Console.WriteLine(a);
                }
            }
        }
    }
}
