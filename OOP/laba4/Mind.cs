/* Разумное существо: Трансформер, Человек: Управление авто*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    public abstract class Mind
    {
        private string type;
        public virtual string Type
        {
            get { return type; }
            set { type = value; }
        }
        public Mind(string _type)
        {
            type = _type;
        }
        public Mind()
        { }
    }
    public class Transformer : Mind
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Transformer(string _type, string _name)
            : base(_type) { 
            Name = _name;
        }
        public Transformer()
        { }
    }
    public class Human : Mind
    {
        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string age;
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        public Human(string _name, string _age, string _type)
        {
            Name = _name;
            Age = _age;
            Type = _type;
        }
        public Human()
        { }
    }
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
