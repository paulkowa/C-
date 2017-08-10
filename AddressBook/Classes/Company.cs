using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Company : Contact
    {
        public String url { get; private set; }
        public Company(string name, string taxId, string address = null, string phoneNumber = null, string url = null) : base(name, taxId, address, phoneNumber)
        {
            this.url = url;
        }

        public void updateUrl(string url)
        {
            this.url = url;
            updateLastModified();
        }
    }
}
