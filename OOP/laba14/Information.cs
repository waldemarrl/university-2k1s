using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

namespace laba14
{
    static class Information
    {
        private static string name_file = "text.txt";
        private static Mutex mutex = new();
        public static void PrintProssecor()
        {
            /*Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет, 
    время запуска, текущее состояние, сколько всего времени использовал процессор и т.д*/           
            var allProcesses = Process.GetProcesses();
            foreach (var process in allProcesses)
            {
                try
                {
                    Console.WriteLine($"Id процессора - {process.Id}\n" +
                                      $"Имя процессора - {process.ProcessName}\n" +
                                      $"Время запуска - {process.StartTime}\n" +
                                      $"Время работы - {process.TotalProcessorTime}\n" +
                                      $"Время загрузки - {process.UserProcessorTime}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        public static void PrintDomen()
        {          
            /*2. Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
    загруженные в домен. Создайте новый домен. Загрузите туда сборку. Выгрузите домен.*/

            AppDomain domain = AppDomain.CurrentDomain;                   // текущий домен с процессами
            Console.WriteLine("Текущий домен:\n" + domain.FriendlyName);
            Console.WriteLine("Базовый каталог:\n" + domain.BaseDirectory);
            Console.WriteLine("Детали конфигурации:\n" + domain.SetupInformation);
            Console.WriteLine("Все сборки в домене:\n");
            foreach (Assembly assembly in domain.GetAssemblies())
                Console.WriteLine(assembly.GetName().Name);

            //AppDomain newDomain = AppDomain.CreateDomain("New Domain"); // создание нового домена
            //newDomain.Load(Assembly.GetExecutingAssembly().FullName);   // загрузка сборки
            //AppDomain.Unload(newDomain);                                // выгрузка домена + всех содержащихся в нём сборок
        }
        public static void PrintNumbers(object counts)
        {
            string count = (string)counts;
            if (int.TryParse(count, out int amount))
            {
                for (int i = 0; i < amount; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(200);
                }
            }
            else
            {
                Console.WriteLine("Это не число");
            }
        }
        public static void PrintTread()
        {           
        /*3. Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для 
    задержки) и записи в файл и на консоль простых чисел от 1 до n (задает пользователь). 
    Вызовите методы управления потоком (запуск, приостановка, возобновление и т.д.) Во 
    время выполнения выведите информацию о статусе потока, имени, приоритете, числовой 
    идентификатор и т.д*/
            Thread NumbersThread = new(new ParameterizedThreadStart(PrintNumbers));
            NumbersThread.Name = "NumbersThread";
            NumbersThread.Start("20");
            Thread.Sleep(1000);
            Console.WriteLine($"После запуска!\n" +
                              $"Имя потока: {NumbersThread.Name},\n" +
                              $"Статус потока: {NumbersThread.ThreadState},\n" +
                              $"Приоритет потока: {NumbersThread.Priority},\n" +
                              $"Идентификатор потока: {NumbersThread.ManagedThreadId}\n");
        }

        public static void OutputEvenNumbers()
        {
            mutex.WaitOne();
            string txt = string.Empty;
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                    txt += i + " ";
                }
            }
            mutex.ReleaseMutex();
            File.AppendAllText(name_file, txt);
        }
        public static void OutputOddNumbers()
        {
            mutex.WaitOne();
            string txt = string.Empty;
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 != 0)
                {
                    Thread.Sleep(100);
                    txt += i + " ";
                    Console.WriteLine(i);
                }
            }
            mutex.ReleaseMutex();
            File.AppendAllText(name_file, txt);
        }

        public static void TwoThreads()
        {
            /*4. Создайте два потока. Первый выводит четные числа, второй нечетные до n и 
            записывают их в общий файл и на консоль. Скорость расчета чисел у потоков – разная.
            a. Поменяйте приоритет одного из потоков. 
            b. Используя средства синхронизации организуйте работу потоков, таким образом, 
            чтобы
            i. выводились сначала четные, потом нечетные числа
            ii. последовательно выводились одно четное, другое нечетное. */
            Thread thread_first = new(OutputEvenNumbers);
            thread_first.Start();
            thread_first.Priority = ThreadPriority.Normal;
            Thread thread_second = new(OutputOddNumbers);
            thread_second.Start();
            thread_second.Priority = ThreadPriority.Highest;
        }
        public static void ReadFile()
        {
            var file = File.ReadAllText(name_file);
            Console.WriteLine(file);
        }
        //создать таймер в 5 сек
        public static void Timer()
        {
            /*5. Создайте таймер, который через каждые 5 секунд выводит на консоль текущее 
            время. При нажатии на любую клавишу таймер должен остановиться.*/
            TimerCallback tm = new TimerCallback(ShowTime);
            Timer timer = new Timer(tm, 0, 0, 1000);
            Console.ReadKey();
            timer.Dispose();
        }
        public static void ShowTime(object obj)
        {
            Console.WriteLine(DateTime.Now);
        }

    }
}
