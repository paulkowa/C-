using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class Program : File
    {
        private decimal tax = 0.0m;
        public Program(int id, string title, string name, decimal price) : base(id, title, name, price)
        {

        }

        public override decimal computePrice()
        {
            return (tax * price) + price;
        }
    }
}
