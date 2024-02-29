using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public class Machine : Transport
    {
        private string name;
        public string Name
        {
            get { return ("Название: " + name); }
            set { name = value; }
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
        public Machine(string _name, string _typeOfMachine)
        {
            Name = _name;
            TypeOfMachine = _typeOfMachine;
        }
        public Machine()
        { }
        public override string ToString()
        {
            string rez = this.Name + this.TypeOfMachine;
            return rez;
        }
    }
}
