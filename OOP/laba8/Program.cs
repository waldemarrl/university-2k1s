using System;

namespace laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            Director d1 = new Director(3000, "director");
            Director d2 = new Director(4500, "director");
            Director d3 = new Director(5000, "director");
            ClassEvent CE = new ClassEvent();

            d1.fine += CE.DoFine;
            d1.increase += CE.DoIncrease;
            d2.fine += CE.DoFine;


            d1.Action(7000, "finantial director");
            Console.WriteLine("----------------------------------------");
            d2.Action(4700, "director");
            Console.WriteLine("----------------------------------------");
            d3.Action(5000, "director");
            string str = "P.   O- i?  T k-l,a ss";
            Func<string, string> A;

            Console.WriteLine("--------------Работа со строками--------------");
            A = Str.RemoveS;
            Console.WriteLine($"Без знаков препинания:\nСтрока до: {str}\nПосле: {A(str)}\n");
            A = Str.RemoveSpase;
            Console.WriteLine($"Убрать пробелы:\nСтрока до: {str}\nПосле: {A(str)}\n");
            A = Str.Upper;
            Console.WriteLine($"Заглавные буквы:\nСтрока до: {str}\nПосле: {A(str)}\n");
            A = Str.Letter;
            Console.WriteLine($"Прописные буквы:\nСтрока до: {str}\nПосле: {A(str)}\n");
            A = Str.AddToString;
            Console.WriteLine($"Добавление символов:\nСтрока до: {str}\nПосле: {A(str)}\n");

            void Hello() => Console.WriteLine("Hello");
            void HowAreYou() => Console.WriteLine("How are you?");

            Message message = Hello;
            message += HowAreYou; 

            message();              
        }
        delegate void Message();
    }
}
