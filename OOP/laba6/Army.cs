using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace laba6
{
    class Army
    {
        public List<object> mainList = new List<object>();

        public List<object> list
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
            list.RemoveAt(num);
        }

        public void Add(object element)
        {
            list.Add(element);
        }

        public void PrintElems()
        {
            foreach (object item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
