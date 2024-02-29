using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace laba9
{
    class Product
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public Product(string name, string amount)
        {
            Name = name;
            Amount = amount;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Amount: {Amount}";
        }
        public override bool Equals(object obj)
        {
            if(obj is Product product)
            {
                return Name == product.Name && Amount == product.Amount;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Amount.GetHashCode();
        }
        //IEnumerator
        //IEnumerable 
        //ICollection
        //IDictionary
        //IList
    }
}
