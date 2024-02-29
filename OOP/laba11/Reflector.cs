using System;
using System.Collections.Generic;
using System.Text;

namespace lab_11
{
    static class Reflector
    {
        public static T Create<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
    class Test : ITest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Test()
        {
            Name = "Default";
            Age = 0;
        }

        public Test(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }

    }
    interface ITest
    {
        void Print();
    }
}
