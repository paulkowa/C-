
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace ConsoleApplication1

{
    class Hr
    {
        static void Main(string[] args)
        {

            NonExemptAssociate a1 = new NonExemptAssociate(123, "Joel", 5.5);
            NonExemptAssociate a2 = new NonExemptAssociate(234, "Vince", 5.5);
            NonExemptAssociate a3 = new NonExemptAssociate(456, "Patrick", 5.5);
            Manager m = new Manager(4892, "Ben", 10.5);
            Department d = new Department("IT", m);

            m.hire(a1);
            m.hire(a2);
            m.hire(a3);

            Console.WriteLine(d.ToString());
        }
    }
}
