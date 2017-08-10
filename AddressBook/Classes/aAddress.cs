using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public abstract class aAddress : IAdress
    {
        private Dictionary<String, Contact> contacts;

        protected aAddress()
        {
            contacts = new Dictionary<String, Contact>();
        }

        public bool addContact(Contact contact)
        {
            if (contacts.ContainsKey(contact.taxId)) { return false; }
            contacts.Add(contact.taxId, contact);
            return true;
        }
        public bool removeContact(Contact contact)
        {
            if(contacts.ContainsKey(contact.taxId))
            {
                contacts.Remove(contact.taxId);
                return true;
            }
            return false;
        }
        public Queue<Contact> getByName(String name)
        {
            Queue<Contact> temp = new Queue<Contact>();
            foreach(KeyValuePair<string, Contact> pair in contacts) { if (pair.Value.name.Equals(name)) { temp.Enqueue(pair.Value); } }
            return temp;
        }
        public Contact getByTaxId(String taxId)
        {
            if (contacts.ContainsKey(taxId)) { return contacts[taxId]; }
            return null;
        }
    }
}
