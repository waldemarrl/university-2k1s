using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public class Human : Mind
    {
        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int power;
        public int Power
        {
            get { return power; }
            set { power = value; 
            }
        }
        private string year;
        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        public Human(string _name, int _power, string _type, string _year)
        {
            Type = _type;
            Name = _name;
            Year = _year;
            Power = _power;
            if (Power <= 0) throw new HException("Неверное значение", GetType().FullName);

        }
        public Human()
        { }
        public override string ToString()
        {
            string rez = this.Type + this.Name + this.Year + this.Power;
            return rez;
        }
    }
}
