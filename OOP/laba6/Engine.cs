using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public class Engine : Transport
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
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
        public virtual string year
        {
            get { return ("Год выпуска двигателя: " + Year); }
            set { Year = value; }
        }
        public override bool DoClone()
        {
            return false;
        }
        public Engine(int _id, string _name, string _power, string _year)
        {
            Id = _id;
            Name = _name;
            Power = _power;
            Year = _year;
        }
        public Engine()
        { }
        public override string ToString()
        {
            string rez = this.Id + this.Name + this.Power + this.Year;
            return rez;
        }
    }
}
