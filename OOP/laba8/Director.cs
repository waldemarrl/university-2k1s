using System;
using System.Collections.Generic;
using System.Text;

namespace laba8
{
    class Director
    {
        public int salary;
        public string position;

        public delegate void Fine(Director obj, int salary);
        public delegate void Increase(Director obj, int salary, string position);
        public event Fine fine;
        public event Increase increase;

        public Director(int salary, string position)
        {
            this.salary = salary;
            this.position = position;
        }

        public void Action(int salary, string position)
        {
            Console.WriteLine(ToString());
            Console.Write("Изменения объекта: ");

            if (fine != null)
            {
                fine(this, salary);
            }
            else
            {
                Console.Write("Зарплата не изменена. ");
            }

            if (increase != null)
            {
                increase(this, salary, position);
            }
            else
            {
                Console.Write("Должность не изменена. ");
            }

            Console.WriteLine();
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Текущие параметры объекта: зарплата = {this.salary}, должность = {this.position}";
        }
    }
}
