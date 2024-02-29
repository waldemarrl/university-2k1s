using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5._1
{
         public abstract class Transport 
        {
            private string model;
            public virtual string Model
            {
                get { return model; }
                set { model = value; }
            }

            private string year;
            public virtual string Year
            {
                get { return year; }
                set { year = value; }
            }

            private int price;
            public virtual int Price
            {
                get { return price; }
                set { price = value; }
            }

            public abstract bool DoClone();

            public Transport(string _model, string _year, int _price )
            {
                model = _model;
                year = _year;
                price = _price;
            }
            public Transport() { }
        public enum Living : short
        {
            Volvo,
            MAZ,
            Renault,
        }
        public Living living;
        struct Comp : ICloneable
        {
            public string type;
            public string model;

            bool ICloneable.DoClone()
            {
                return false;
            }

            public void Print()
            {
                Console.WriteLine($"Модель: {model}   Тип: {type}");
            }
        }
        Comp compare = new Comp();
    }
}
