using System;
using System.Collections.Generic;

namespace laba5._1
{
    class Program
        static void Main(string[] args)
        {
            Machine mac1 = new Machine("40sq/m", "truck", "Volvo500", "2013", 15000);
            Machine mac2 = new Machine("10sq/m", "van", "Ford Transit", "2016", 3000);
            List<object> agent1 = new List<object> { mac1, mac2 };
            Agency agent = new Agency();
            agent.mainList = agent1;

           

            agent.PrintElems();
            Machine mac3 = new Machine("15sq/m", "van", "Ford Transit", "2018", 5000);
            agent.Add(mac3);
            agent.Remove(2);
            Console.WriteLine("------------------------------------");
            agent.PrintElems();
            Console.WriteLine("------------------------------------");

            Controller cntrl = new Controller();
            cntrl.Search(agent, "2013");
            agent.PrintElems();
            cntrl.Print(agent, "2018");
            cntrl.ElementCounter(agent);

        }
    }
}
