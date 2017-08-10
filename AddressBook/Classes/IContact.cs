using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    interface IContact
    {
        bool checkTaxId(string taxId);
        void updateName(string name);
        void updateAddress(string address);
        void updatePhoneNumber(string phoneNumber);
    }
}
