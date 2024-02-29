using System;

namespace lab_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test("Alexey", 18);
            Reflector.Create<Test>();
            Reflection.GetAssemblyName(typeof(Test));
            Reflection.GetConstructors(typeof(Test));
            Reflection.GetMethods(typeof(Test));
            Reflection.GetProperties(typeof(Test));
            Reflection.GetFields(typeof(Test));
        }
    }
}
