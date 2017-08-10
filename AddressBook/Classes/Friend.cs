using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Friend : Contact
    {
        public String email { get; private set; }
        public DateTime birthday { get; private set; }
        public Friend(string name, string taxId, string address = null, string phoneNumber = null, string email = null) : base(name, taxId, address, phoneNumber)
        {
            this.email = email;
        }
        public void updateEmail(string email)
        {
            this.email = email;
            updateLastModified();
        }

        public void updateBirthday(DateTime birthday)
        {
            this.birthday = birthday;
            updateLastModified();
        }

    }
}
