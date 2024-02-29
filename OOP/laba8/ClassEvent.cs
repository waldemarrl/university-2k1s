using System;
using System.Collections.Generic;
using System.Text;

namespace laba8
{
    class ClassEvent
    {
        public void DoFine(Director obj, int salary)
        {
            obj.salary = salary;
            Console.Write($"Новая зарплата директора = {salary}. ");
        }

        public void DoIncrease(Director obj, int salary, string position)
        {
            obj.salary = salary;
            obj.position = position;
            Console.Write($"Новые зарплата и должность = {salary}\t{position}");
        }
    }
}
