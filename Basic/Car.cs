using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    class Car
    {
        private double efficiency;
        private double gasInTank;
        public Car()
        {
            efficiency = 0;
            gasInTank = 0;
        }

        public Car(int mpg, int gas)
        {
            efficiency = mpg;
            gasInTank = gas;
        }

        public void drive(int i)
        {
            gasInTank = gasInTank - (i / efficiency);
        }

        public double checkTank()
        {
            return gasInTank;
        }

    }
}
