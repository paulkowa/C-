using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    interface IAdress
    {
        bool addContact(Contact contact);
        bool removeContact(Contact contact);
        Queue<Contact> getByName(String name);
        Contact getByTaxId(String taxId);
    }
}
