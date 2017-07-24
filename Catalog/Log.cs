using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class Log
    {
        Dictionary<int, File> catalog;

        public Log()
        {
            catalog = new Dictionary<int, File>();
        }

        public bool addItem(File f)
        {
            catalog.Add(f.id, f);
            return catalog.ContainsKey(f.id);
        }

        public bool removeItem(File f)
        {
            catalog.Remove(f.id);
            return catalog.ContainsKey(f.id);
        }
        
        public string getLog()
        {
            var items = "";

            foreach(KeyValuePair<int, File> item in catalog) {
                items += item.Key + " " + item.Value.title + "\n";
            }
            return items;
        }

        public void purchase(int id)
        {
            Console.WriteLine(catalog[id].computePrice());
        }
    }
}
