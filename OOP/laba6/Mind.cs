using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public abstract partial class Mind
    {
        private string type;
        public virtual string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string power;
        public string Power
        {
            get { return power; }
            set { power = value; }
        }
        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public Mind(string _type, string _name, int _year, string _power)
        {
            Type = _type;
            Name = _name;
            Year = _year;
            if (year <= 0) throw new MException("Неверное значение", GetType().FullName);
            Power = _power;
        }
        public Mind()
        { }
        public enum LivingMind
        {
            soldier,
            bamblee,
            optimusprime
        }
        public LivingMind livingmind;
        struct mind
        {
            public string type;
            public string name;
            public void Print()
            {
                Console.WriteLine($"Имя: {name}   Тип: {type}");
            }
        }
    }
}
