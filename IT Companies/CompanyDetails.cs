using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Companies
{
    class CompanyDetails
    {
        private string _name;
        private string _address;

        public string get_Name()
        {
            return this._name;
        }

        public void set_Name(string name)
        {
            this._name = name;
        }
        
        public string get_Address()
        {
            return this._address;
        }

        public void set_Address(string address)
        {
            this._address = address;
        }

        public override string ToString()
        {
            return _name + "\r\n\n" + _address;
        }
    }
}
