using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            int? aa = null;
            Debug.Assert(aa != null, "Values array cannot be null");

            for (int i = 1; i < 4; i++)
            {
                try
                {
                    switch (i)
                    {
                        case 1:
                            Human hu1 = new Human("soldier", -12, "Sam", "2001");
                            break;
                        case 2:
                            Human hu2 = new Human("soldier", 20, "Sam", "1999");
                            break;
                        case 3:
                            Human hu3 = new Human("soldier", 0, "Sam", "2002");
                            break;
                    }
                }
                catch (MException ex)
                {
                    Console.WriteLine(ex.Message);
                   
                }
                catch (HException ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine($"Это сообщение из блока finnaly");
                    Console.WriteLine("-------------------------------");
                }
            }
        }
    }
}
