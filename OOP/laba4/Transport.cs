/*Транспортное средство: Двигатель: Машина*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    interface IClonable
    {
        bool DoClone();
    }


    public abstract class Transport
    {
        private string typeOfMovement;
        public virtual string TypeOfMovement
        {
            get { return typeOfMovement; }
            set { typeOfMovement = value; }
        }

        private string year;
        public virtual string Year
        {
            get { return year; }
            set { year = value; }
        }
        public abstract bool DoClone();
        public Transport(string _typeOfMovement, string _year)
        {
            typeOfMovement = _typeOfMovement;
            year = _year;
        }
        public Transport(string _typeOfMovement)
        {
            typeOfMovement = _typeOfMovement;
            year = null;
        }
        public Transport()
        {
            typeOfMovement = null;
            year = null;
        }
    }
    public class Engine : Transport, IClonable
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

         bool IClonable  DoClone()
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
    public sealed class Machine : Transport
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

    public class Printer
    {
        public string IAmPrinting(Transport someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(Engine someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(Machine someobj)
        {
            return someobj.ToString();
        }
    }
}
