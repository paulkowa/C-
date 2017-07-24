using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public abstract class File
    {
        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public File()
        {

        }

        public File(int id, string title, string name, decimal price)
        {
            this.id = id;
            this.title = title;
            this.name = name;
            this.price = price;
        }

        public abstract decimal computePrice();
        
    }
}
