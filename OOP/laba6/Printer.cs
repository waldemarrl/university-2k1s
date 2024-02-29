using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
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
        public string IAmPrinting(Human someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(Transformer someobj)
        {
            return someobj.ToString();
        }
    }
}
