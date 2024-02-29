using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba6
{
    public class Management : Human
    {
        private string term;
        public string Term
        {
            get { return term; }
            set { term = value; }
        }
        public Management(string _name, string _term)
        {
            Name = _name;
            Term = _term;
        }
    }
}
