using System;
using System.Collections.Generic;
using System.Text;

namespace laba13
{
    [Serializable]
    public abstract class Testing
    {
        protected string _name;
        protected int _time;
        public virtual string Name
        {
            get => _name;
            set => _name = value;
        }

        public virtual int Time
        {
            get => _time;
            set => _time = value;
        }
        public Testing()
        {
            Name = "Default";
            Time = 0;

        }
        public Testing(string name, int time)
        {
            Name = name;
            Time = time;

        }
        public override string ToString()
        {
            return $"Name: {Name}, Time: {Time}";
        }
        public virtual void Successfully() => Console.WriteLine("Успешно испытание");
        public abstract void Failed();
    }
}
