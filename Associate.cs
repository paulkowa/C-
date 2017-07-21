using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Associate
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

        public abstract double computeWeeklyPay(double hours);

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
