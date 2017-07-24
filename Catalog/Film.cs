using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class Film : File
    {
        public string director { get; set; }
        private decimal tax = 0.15m;

        public Film(int id, string title, string name, decimal price, string director) : base(id, title, name, price)
        {
            this.director = director;
        }

        public override decimal computePrice()
        {
            return (tax * price) + price;
        }
    }
}
