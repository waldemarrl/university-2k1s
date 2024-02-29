using System;
using System.Collections.Generic;
using System.Linq;

namespace laba10
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                string[] months = {"January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December", };

                int n = 4;
                var SelectedMonths1 = from t in months
                                      where t.Length == n
                                      select t;

                var SelectedMonths2 = from t in months
                                      where t == "June" || t == "July" || t == "August" || t == "December" || t == "January" || t == "February"
                                      select t;

                var SelectedMonths3 = from t in months
                                      orderby t
                                      select t;

                var SelectedMonths4 = from t in months
                                      where t.Contains("u")
                                      where t.Length >= 4
                                      select t;

                foreach (var item in SelectedMonths1)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("-------------------------------------");
                foreach (var item in SelectedMonths2)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("-------------------------------------");
                foreach (var item in SelectedMonths3)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("-------------------------------------");
                foreach (var item in SelectedMonths4)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("-------------------------------------");
            }
            {
                List<Students> students = new List<Students>();
                students.Add(new Students("Boris", "Galen", 19, 3, "POIT", "FIT"));
                students.Add(new Students("Alexander", "Manchik", 19, 2, "ISaT", "FIT"));
                students.Add(new Students("Andrew", "Kor", 20, 1, "POIT", "FIT"));
                students.Add(new Students("Gena", "Landr", 18, 2, "POIT", "FIT"));
                students.Add(new Students("Ben", "Collins", 19, 2, "ISaT", "FIT"));
                students.Add(new Students("Boris", "John", 19, 3, "ISaT", "FIT"));
                students.Add(new Students("Sam", "Green", 19, 2, "POIT", "FIT"));

                var query1 = from item in students
                             where item.Speciality == "ISaT"
                             orderby item.Surname
                             select item;
                var query2 = from item in students
                             where item.Group == 3
                             where item.Speciality == "POIT"
                             select item;
                var query3 = students
                             .OrderBy(item => item.Age)
                             .First();
                var query4 = students
                    .Where(item => item.Group == 3)
                    .Where(item => item.Surname == "John")
                    .Count();
                var query5 = students
                    .Where(item => item.Name == "Boris")
                    .First();

                foreach(var item in query1)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Студенты 3 группы специальности POIT");
                foreach(var item in query2)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Самый молодой студент: {query3} ");
                Console.WriteLine($"Студенты 3 группы с фамилией John: {query4} ");
                Console.WriteLine($"Первый студент с именем Boris: {query5} ");
                Console.WriteLine("-------------------------------------");
                {
                    //4
                    var query6 = students
                        .GroupBy(item => item.Group)
                        .Select(
                        item => new
                        {
                            Name = item.Key,
                            Count = item.Count()
                        }
                        )
                        .Where(item => item.Count < 5)
                        .OrderBy(item => item.Name)
                        .Take(2);
                    foreach(var item in query6)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    Console.WriteLine("-------------------------------------");
                }

                {
                    //5
                    int[] key = { 1, 5, 6 };
                    var query7 = students
                        .Join(
                        key,
                        item => item.Surname.Length,
                        t => t,
                        (item, t) => new
                        {
                            Surname = item.Surname,
                            key = string.Format($"{t}")
                        }
                        );
                    foreach(var item in query7)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
        }
    }
}
