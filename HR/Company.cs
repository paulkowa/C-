using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Company
    {
        Dictionary<int, Associate> d;

        public List<Associate> l {
            get { return d.Values.ToList(); }
            set { }
        }

        public Company()
        {
            d = new Dictionary<int, Associate>();
        }

        public void AddAssociate(Associate a)
        {
            if(d.ContainsKey(a.associateNum)) {
                d[a.associateNum] = a;
                return;
            }

            d.Add(a.associateNum, a);
        }

        public Associate GetAssociate(int anum)
        {
            if (d.ContainsKey(anum)) { return d[anum]; }
            return null;
        }

        public bool RemoveAssociate(int anum)
        {
            return d.Remove(anum);
        }

    }
}
