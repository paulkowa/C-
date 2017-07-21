using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class NonExemptAssociate : Associate
    {
        public NonExemptAssociate(int associateNum, string name, double pay) : base(associateNum, name, pay)
        {

        }

        public override double computeWeeklyPay(double hours)
        {
            if (hours <= 40) { return hours * pay; }
            return (40 * pay) + ((hours - 40) * 1.5 * pay);
        }
    }
}
