using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public abstract class Contact : IContact
    {
        public string name { get; private set; }
        public string taxId { get; private set; }
        public string address { get; private set; }
        public string phoneNumber { get; private set; }
        public DateTime dateCreated { get; private set; }
        public DateTime lastModified { get; private set; }

        protected Contact(String name, String taxId, String address = null, string phoneNumber = null)
        {
            this.name = name;
            this.taxId = taxId;
            this.address = address;
            this.phoneNumber = phoneNumber;
            lastModified = dateCreated = DateTime.Now;
        }

        public bool checkTaxId(string taxId)
        {
            return taxId != this.taxId;
        }

        public void updateName(string name)
        {
            this.name = name;
            updateLastModified();
        }

        public void updateAddress(string address)
        {
            this.address = address;
            updateLastModified();
        }

        public void updatePhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            updateLastModified();
        }

        protected void updateLastModified()
        {
            lastModified = DateTime.Now;
        }
    }
}
