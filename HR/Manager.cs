﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Manager : ExemptAssociate
    {
        private List<Associate> associates;

        public Manager(int associateNum, string name, double pay) : base(associateNum, name, pay)
        {
            associates = new List<Associate>();
        }

        public bool addAssociate(Associate a)
        {
            if (associates.Count < 10)
            {
                associates.Add(a);
                return true;
            }

            return false;

        }

        public void hire(Associate a)
        {
            if (addAssociate(a)) { return; }
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
