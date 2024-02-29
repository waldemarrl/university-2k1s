using System;
using System.Collections.Generic;
using System.Text;

namespace laba5._1
{
    public class Engine : Transport, ICloneable
    {
        private int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private string power;
        public string Power
        {
            get { return power; }
            set { power = value; }
        }
        public sealed override bool DoClone()
        {
            return false;
        }

        public Engine(int _speed, string _model, string _power, string _year)
        {
            Speed = _speed;
            Model = _model;
            Power = _power;
            Year = _year;
        }
        public Engine()
        { }
        public override string ToString()
        {
            string rez = this.Speed + this.Model + this.Power + this.Year;
            return rez;
        }
    }
}
