using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Classes
{
    class Department
    {
        Manager m { get; set; }
        string name { get; set; }

        public Department(string name, Manager m)
        {
            this.name = name;
            this.m = m;
        }

        public override string ToString()
        {
            string reports = "\nAssociates:\n\t";
            Associate[] a = m.directReports();
            for (int i = 0; i < a.Length; i++) { reports += a[i].ToString() + "\n\t"; }

            return "Department: " + name + "\n" + m.ToString() + reports;
        }
    }
}
