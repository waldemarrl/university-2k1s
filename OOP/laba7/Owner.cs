using System;
using System.Collections.Generic;
using System.Text;

namespace laba7
{
    public class Owner
    {
        private readonly int id;
        private readonly string fio;

        public Owner(int id, string fio)
        {
            this.id = id;
            this.fio = fio;
        }
        public override string ToString()
        {
            return "Тип объекта: " + base.ToString() + $", id: {id}, fio: {fio}";
        }
    }
}
