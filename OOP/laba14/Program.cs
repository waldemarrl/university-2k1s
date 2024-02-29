using System;
using System.Threading;

namespace laba14
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Information.Timer();
                Console.WriteLine("\n-----------------1------------------\n");
                Information.PrintProssecor();          
                Console.WriteLine("\n-----------------2------------------\n");
                Information.PrintDomen();
                Console.WriteLine("\n-----------------3------------------\n");
                Information.PrintTread();
                Thread.Sleep(3000);
                Console.WriteLine("\n-----------------4------------------\n");
                Information.TwoThreads();
                Thread.Sleep(3000);
                Console.WriteLine("\n--------------------Text file--------------------\n");
                Information.ReadFile();
                Console.WriteLine("\n--------------------------------------------------\n");
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
