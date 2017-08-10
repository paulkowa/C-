using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Work : Contact
    {
        public String email { get; private set; }
        public String title { get; private set; }
        public String employer { get; private set; }
        public String url { get; private set; }

        public Work(string name, string taxId, string address = null, string phoneNumber = null, string email = null, string title = null, string employer = null, string url = null) : base(name, taxId, address, phoneNumber)
        {
            this.email = email;
            this.title = title;
            this.employer = employer;
            this.url = url;
        }

        public void updateEmail(string email)
        {
            this.email = email;
            updateLastModified();
        }
        public void updateTitle(string title)
        {
            this.title = title;
            updateLastModified();
        }
        public void updateEmployer(string employer)
        {
            this.employer = employer;
            updateLastModified();
        }
        public void updateUrl(string url)
        {
            this.url = url;
            updateLastModified();
        }
    }
}
