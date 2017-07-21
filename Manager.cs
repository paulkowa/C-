using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Manager : Associate
    {
        private List<Associate> associates;

        public Manager(int associateNum, string name, double pay) : base(associateNum, name, pay)
        {
            associates = new List<Associate>();
        }

        public double computeWeeklyPay()
        {
            return 38.75 * pay;
        }

        public bool addAssociate(Associate a)
        {
            if (associates.Count < 10)
            {
                associates.Add(a);
                return true;
            }

            else { return false; }

        }

        public void hire(Associate a)
        {
            if (addAssociate(a)) { return; }
            Console.WriteLine("Unable to add associate.");
        }

        public void giveRaise(Associate a, double raise)
        {
            a.raisePay(raise);
        }

        public Associate[] directReports()
        {
            return associates.ToArray();
        }

        public override string ToString()
        {
            return "Manager: " + name + " (" + associateNum + ")";
        }
    }
}
