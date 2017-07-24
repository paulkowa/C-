using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    class Catalog
    {
        static void Main(string[] args)
        {
            Log l = new Log();

            l.addItem(new Film(101, "Road to Perdition", "road.exe", 10.99m, "Some guy"));
            l.addItem(new Film(102, "Master and Commander", "mac.exe", 10.99m, "Some guy"));
            l.addItem(new Film(103, "Gattaca", "gattaca.exe", 10.99m, "Some guy"));

            l.addItem(new Music(204, "Grace Too", "grace.exe", 10.99m, "The Tragically Hip"));
            l.addItem(new Music(205, "About Today", "today.exe", 10.99m, "The Nationals"));
            l.addItem(new Music(206, "Bilgewater", "bilgewater.exe", 10.99m, "Brown Bird"));

            l.addItem(new Program(3017, "World of Warcraft", "WoW.exe", 10.99m));
            l.addItem(new Program(3015, "Civilization", "civ.exe", 10.99m));
            l.addItem(new Program(3014, "Resident Evil 4", "re4.exe", 10.99m));

            Console.WriteLine(l.getLog());
            l.purchase(101);
            l.purchase(204);
            l.purchase(3017);
        }
    }
}
