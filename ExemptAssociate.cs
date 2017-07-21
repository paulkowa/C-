using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class ExemptAssociate : Associate
    {
        public ExemptAssociate(int associateNum, string name, double pay) : base(associateNum, name, pay)
        {
        }

        public override double computeWeeklyPay(double hours)
        {
            return pay * 38.75;
        }
    }
}
