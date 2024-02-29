using System;
using System.Collections.Generic;
using System.Text;

namespace laba5._1
{
    public sealed class Machine : Transport
    {
        private string size;
        public string Size
        {
            get { return ("Вместимость: " + size); }
            set { size = value; }
        }
        private string typeOfMachine;
        public string TypeOfMachine
        {
            get { return typeOfMachine; }
            set { typeOfMachine = value; }
        }
        public override bool DoClone()
        {
            return false;
        }

        

        public Machine(string _size, string _typeOfMachine, string _model, string _year, int _price)
        {
            Model = _model; 
            Size = _size;
            TypeOfMachine = _typeOfMachine;
            Year = _year;
            Price = _price;
        }
        public Machine()
        { }
        public override string ToString()
        {
            string rez = this.Size + this.TypeOfMachine;
            return rez;
        }
    }
}
