using System;
using System.Collections.Generic;
using System.Text;

namespace laba5._1
{
    class Controller : ICloneable
    {

        bool ICloneable.DoClone()
        {
            return false;
        }

        public void Search(Agency agent, string year)
        {
            foreach (Transport item in agent.List)
            {
                if (item.Year == year) Console.WriteLine(item.ToString());
            }
        }
        public void Print(Agency agent, string size)
        {
            foreach (Machine item in agent.List)
            {
                if (item.Size == size) Console.WriteLine(item.ToString());
            }
        }
        public void ElementCounter(Agency agent)
        {
            int sum = 0;
            foreach (object item in agent.List)
            {
                sum++;
            }
            Console.WriteLine($"Количество машин = {sum}");
        }
    }
}
