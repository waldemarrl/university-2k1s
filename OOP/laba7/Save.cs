using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace laba7
{
    public static class Save<T>
    {
        public static void WriteToFile(List<T> arr)
        {
            StreamWriter file = new StreamWriter("file.txt", false);

            foreach (var item in arr)
            {
                file.Write($"{item}\n");
            }

            file.Close();
        }

        public static void ReadFromFile()
        {
            StreamReader file = new StreamReader("file.txt", true);
            Console.WriteLine(file.ReadToEnd());
            file.Close();
        }
    }
}
