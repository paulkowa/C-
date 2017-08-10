using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Gooey
    {
        private Address address;
        private MainWindow window;
        public Gooey(MainWindow window)
        {
            address = new Address();
            this.window = window;
        }
    }
}
