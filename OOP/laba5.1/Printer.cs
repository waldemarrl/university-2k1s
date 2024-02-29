using System;
using System.Collections.Generic;
using System.Text;

namespace laba5._1
{
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
