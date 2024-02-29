using System;
using System.Collections.Generic;

namespace laba7
{
    class Program
    {
        static void Main(string[] args)
        {
           //CollectionType<int>.code = 1234;
            try
            {
                CollectionType<Owner> cl1 = new CollectionType<Owner>();
                CollectionType<SomeClass> cl2 = new CollectionType<SomeClass>();
                Owner cr1 = new Owner(1, "Vladimir");
                Owner cr2 = new Owner(2, "Dima");
                Owner cr3 = new Owner(3, "Egor");
                Owner cr4 = new Owner(4, "Pasha");
                List<Owner> ls1 = new List<Owner>() { cr1, cr2, cr3 };

                cl1.Collection = ls1;
                Console.WriteLine("------------cl1-------------");
                cl1.Show();
                cl1.Add(cr4);
                cl1.Delete(cr1);
                Console.WriteLine("-------------------------");
                cl1.Show();
                Console.WriteLine("-------------------------");

                SomeClass sc1 = new SomeClass("glo");
                SomeClass sc2 = new SomeClass("dfg");
                SomeClass sc3 = new SomeClass("ppp");
                SomeClass sc4 = new SomeClass("k}]");
                List<SomeClass> ls2 = new List<SomeClass> { sc1, sc2, sc3 };

                cl2.Collection = ls2;
                Console.WriteLine("------------cl2-------------");
                cl2.Show();
                cl2.Add(sc4);
                cl2.Delete(sc2);
                Console.WriteLine("-------------------------");
                cl2.Show();
                Console.WriteLine("-------------------------");

                Console.WriteLine("------------file-------------");
                Save<Owner>.WriteToFile(cl1.Collection);
                Save<Owner>.ReadFromFile();
                Console.WriteLine("-------------------------");

                List<int> a = new List<int> { 1, 2, 3 };
                Save<int>.WriteToFile(a);
                Save<int>.ReadFromFile();
                Console.WriteLine("-------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("FINALLY");
            }
        }
    }
}
