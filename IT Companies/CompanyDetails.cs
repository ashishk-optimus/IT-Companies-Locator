using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Companies
{
    class CompanyDetails
    {
        private string name;
        private string address;

        public string getName() => this.name;

        public void setName(string name) => this.name = name;

        public string Address => this.address;

        public void setAddress(string address) => this.address = address;

        public override string ToString()
        {
            return name + "\r\n\n" + address;
        }
    }
}
