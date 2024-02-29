using System;
using System.Collections.Generic;
using System.Text;

namespace laba6
{
    class Controller
    {
        public void Search(Army arm, int year)
        {
            foreach (Mind item in arm.list)
            {
                if (item.Year == year) Console.WriteLine(item.ToString());
            }
        }
        public void Print(Army arm, string power)
        {
            foreach (Mind item in arm.list)
            {
                if (item.Power == power) Console.WriteLine(item.ToString());
            }
        }
        public void ElementCounter(Army arm)
        {
            int sum = 0;
            foreach (object item in arm.list)
            {
                sum++;
            }
            Console.WriteLine($"Количество боевых единиц = {sum}");
        }
    }
}
