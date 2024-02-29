using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public abstract partial class Transport
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
}
