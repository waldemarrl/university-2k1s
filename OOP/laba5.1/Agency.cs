using System;
using System.Collections.Generic;
using System.Text;

namespace laba5._1
{
        class Agency
        {
            public List<object> mainList = new List<object>();

            public List<object> List
            {
                get { return mainList; }
                set
                {
                    if (value == null) { Console.WriteLine("Ошибка"); }
                    else { mainList = value; }
                }
            }

            public void Remove(int num)
            {
                List.RemoveAt(num);
            }

            public void Add(object element)
            {
                List.Add(element);
            }

            public void PrintElems()
            {
                foreach (object item in List)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
}
