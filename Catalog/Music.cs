using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class Music : File
    {
        public string artist { get; set; }
        private decimal tax = 0.1m;

        public Music(int id, string title, string name, decimal price, string artist) : base(id, title, name, price)
        {
            this.artist = artist;
        }

        public override decimal computePrice()
        {
            return (tax * price) + price;
        }
    }
}