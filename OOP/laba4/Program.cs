using System;
using System.Collections.Generic;

namespace laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine1 = new Engine(1, "JS2", "600HP", "1987");
            Console.WriteLine(engine1.Name);
            Machine machine1 = new Machine("Porsche Taycan", "electro");
            Console.WriteLine(machine1.Name + ", " + machine1.TypeOfMachine);

            Human human1 = new Human("Maxim", "20", "Man");
            Management manage1 = new Management("Maxim", "20");
            human1 = manage1 as Human;
            if (manage1 is Human)
            {
                Console.WriteLine("GetIn");
            }

            List<Transport> list = new List<Transport> { new Engine(2, "JS1", "500HP", "1980"), new Machine("BMW M4", "gas") };
            Printer printer = new Printer();
            foreach( Transport t in list)
            {
                Console.WriteLine(printer.IAmPrinting(t));
            }
        }
    }
}
