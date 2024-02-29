using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;

namespace laba15
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new();
            Class1.task1 = new(() => Class1.SieveOfEratosthenes());
            Class1.task1.Start();
            watch.Start();
            Class1.task1.Wait(); // ожидание завершения задачи 
            Class1.task1.Dispose(); // Освобождение ресурсов
            watch.Stop();
            Console.WriteLine("Таск выполнен: " + Class1.task1.IsCompleted.ToString());
            Console.WriteLine("Статус: " + Class1.task1.Status.ToString());
            Console.WriteLine("Время выполнения для таска: " + watch.Elapsed);

            int[,] matrix1 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matrix2 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Class1.task1 = new(() => Class1.MatrixMultiplication(matrix1, matrix2));
            Class1.task1.Start();
            Class1.task1.Wait();
            Class1.task1.Dispose();
            Console.WriteLine("Таск выполнен: " + Class1.task1.IsCompleted.ToString());
            Console.WriteLine("Статус: " + Class1.task1.Status.ToString());

            Console.WriteLine("\n\n-------------------2------------------------\n\n");
            CancellationTokenSource token = new();
            (Class1.task1 = new Task(() => Class1.SieveOfEratosthenes(), token.Token)).Start();
            token.Cancel();
            Console.WriteLine("Токен отмены сработал!");

            Console.WriteLine("\n\n-------------------3------------------------\n\n");
            Task<int> rand1 = new Task<int>(Class2.RandomFor10), // создание задачи с возвращаемым значением
                      rand2 = new Task<int>(Class2.RandomFor20),
                      rand3 = new Task<int>(Class2.RandomFor30);
            rand1.Start();
            Console.WriteLine("First Value: " + rand1.Result);
            rand2.Start();
            Console.WriteLine("Second Value: " + rand2.Result);
            rand3.Start();
            Console.WriteLine("Third Value: " + rand3.Result);
            Task<int> avg = new Task<int>(() => Class2.AverageValue(rand1.Result, rand2.Result, rand3.Result));
            avg.Start();
            Console.WriteLine("Average: " + avg.Result);

            Console.WriteLine("\n\n-------------------4------------------------\n\n");
            Console.WriteLine("Таск продолжения: ");
            Task<int> contTask1 = new Task<int>(Class2.RandomFor10);

            Task<int> contTask2 = contTask1.ContinueWith((task) => Class2.RandomFor20());
            Task<int> contTask3 = contTask2.ContinueWith((task) => Class2.RandomFor30());
            Task<int> contTask4 = contTask3.ContinueWith((task) => Class2.AverageValue(contTask1.Result, contTask2.Result, contTask3.Result));
            contTask1.Start();
            //ContinueWith 

            Console.WriteLine($"Первое значение:  {contTask1.Result}\n" +
                              $"Второе значение: {contTask2.Result}\n" +
                              $"Третье значение: {contTask3.Result}\n" +
                              $"Среднее значение: {contTask4.Result}\n");
            contTask1.Dispose();
            contTask2.Dispose();
            contTask3.Dispose();
            contTask4.Dispose();
            Console.WriteLine("Ожидающий");
            Task<int> wait = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
            wait.GetAwaiter().GetResult();
            Console.WriteLine(wait.Result);

            Console.WriteLine("\n\n-------------------5------------------------\n\n");
            Stopwatch stW = new();
            int[] arr1 = new int[10000000];
            int[] arr2 = new int[10000000];
            Random random = new Random();
            stW.Start(); // запуск таймера

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = random.Next(0, 100);
                arr2[i] = random.Next(0, 100);
            }
            stW.Stop();

            Console.WriteLine("For: " + stW.Elapsed);
            stW.Restart();

            Parallel.For(0, arr1.Length, i =>
            {
                arr1[i] = random.Next(0, 100);
                arr2[i] = random.Next(0, 100);
            });
            stW.Stop();

            Console.WriteLine("Параллельный for: " + stW.Elapsed);
            stW.Restart();

            Parallel.ForEach<int>(arr1, i =>
            {
                arr1[i] = random.Next(0, 300);
                arr2[i] = random.Next(0, 300);
            });
            stW.Stop();

            Console.WriteLine("Параллельный foreach: " + stW.Elapsed);

            Console.WriteLine("\n\n-------------------6------------------------\n\n");
            Parallel.Invoke(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Параллельное выполнение блока 1 - " + i);
                }

                Console.WriteLine("1 готов!");
            },
               () =>
               {
                   for (int i = 0; i < 10; i++)
                   {
                       Console.WriteLine("Параллельное выполнение 2 - " + i);
                   }

                   Console.WriteLine("2 готов!");
               });

            Console.WriteLine("\n\n-------------------7------------------------\n\n");
            Class3.MyBlock = new BlockingCollection<string>(5);
            Task Shop = new Task(Class3.AddProduct);
            Task Clients = new Task(Class3.PurchasedProduct);
            Shop.Start();
            Clients.Start();
            Shop.Wait();
            Clients.Wait();

            Console.WriteLine("\n\n-------------------8------------------------\n\n");
            Class4.Async();
            string p = Console.ReadLine();
            Console.WriteLine(p + p + p + "Нажмите, чтобы закончить работу...");
        }
    }
}
