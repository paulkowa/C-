using System;
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

            Associate a1 = new Associate(123, "Joel", 5.5);
            Associate a2 = new Associate(234, "Vince", 5.5);
            Associate a3 = new Associate(456, "Patrick", 5.5);
            Manager m = new Manager(4892, "Ben", 10.5);
            Department d = new Department("IT", m);

            m.hire(a1);
            m.hire(a2);
            m.hire(a3);

            Console.WriteLine(d.ToString());
        }
    }
}
