using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Associate
    {
        public int associateNum { get; private set; }
        public string name { get; set; }
        public double pay { get; private set; }

        public Associate(int associateNum, string name, double pay)
        {
            this.associateNum = associateNum;
            this.name = name;
            this.pay = pay;
        }

        public virtual double computeWeeklyPay(double hours)
        {
            if (hours <= 40) { return hours * pay; }
            return (40 * pay) + ((hours - 40) * 1.5 * pay);
        }

        public void raisePay(double pay)
        {
            this.pay += pay;
        }

        public override string ToString()
        {
            return name + " (" + associateNum + ")";
        }
    }
}
