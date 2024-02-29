using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public class Transformer : Mind
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string year;
        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        private string power;
        public string Power
        {
            get { return power; }
            set { power = value; }
        }
        public Transformer(string _type, string _name, string _year, string _power)
        {
            Type = _type;
            Name = _name;
            Year = _year;
            Power = _power;
        }
        public Transformer()
        { }
        public override string ToString()
        {
            string rez = this.Type + this.Name + this.Year + this.Power;
            return rez;
        }
    }
}
