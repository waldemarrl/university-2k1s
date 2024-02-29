using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace laba15
{
    class Class4
    {
        public static void ForAsync()
        {
            for (int i = 0; i < 30; i++)
                if (i % 3 == 0)
                {
                    Console.Write(i + ", ");
                    Thread.Sleep(1000);
                }
        }
        public static async void Async()
        {
            Console.WriteLine("Асинхронная функция:");
            await Task.Run(() => ForAsync());
            Console.WriteLine("Готово!");
        }
    }
}
