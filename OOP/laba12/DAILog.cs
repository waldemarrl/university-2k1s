using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace laba12
{
    static class DAILog
    {
        private const string PATH_TO_FILE = "dailogfile.json";
        public static void WriteToFile(string methodName, string className)
        {
            Data datas = new(methodName, className);
            datas.Print();
            var newData = JsonSerializer.Serialize(datas);
            using (StreamWriter sw = new(PATH_TO_FILE, true))
            {
                sw.WriteLine(newData);
            }
        }
        public static void FindByDate(DateTime start, DateTime end)
        {
            using (StreamReader sr = new(PATH_TO_FILE))
            {
                while (!sr.EndOfStream)
                {
                    var data = sr.ReadLine();
                    var datas = JsonSerializer.Deserialize<Data>(data);
                    List<Data> datas1 = new();
                    datas1.Add(datas);
                    datas1.Where(d => d.date >= start && d.date <= end).ToList().ForEach(d => d.Print());
                }
            }
        }
        public static void FindDate(DateTime date)
        {
            using (StreamReader sr = new(PATH_TO_FILE))
            {
                while (!sr.EndOfStream)
                {
                    var data = sr.ReadLine();
                    var datas = JsonSerializer.Deserialize<Data>(data);
                    List<Data> datas1 = new();
                    datas1.Add(datas);
                    datas1.Where(d => d.date == date).ToList().ForEach(d => d.Print());
                }
            }
        }
    }
    class Data
    {
        public string Name { get; set; }
        public DateTime date { get; set; }
        public string NameClass { get; set; }
        public Data(string methodName, string className)
        {
            Name = methodName ;
            NameClass = className ;
            date = DateTime.Now;
        }
        public void Print()
        {
            Console.WriteLine($"{Name} {date} {NameClass}");
        }
    }
}
