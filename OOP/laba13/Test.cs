using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace laba13
{
    [Serializable]
    public class Test : Testing, ITest
    {
        private string v1;
        private string v2;
        public Test()
        {
            Name = "Default";
            Time = 0;
        }
        public Test(string name, int time, int mark) : base(name, time)
        {
            Name = name;
            Time = time;
        }
        public Test(string name, int time, int mark, string v1, string v2) : this(name, time, mark)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
        public override void Successfully()
        {
            base.Successfully();
        }
        public override void Failed()
        {
            Console.WriteLine(" Failed");
        }

        public override string ToString()
        {
            return base.ToString() + $"Type_challenges: ";
        }
    }
}

