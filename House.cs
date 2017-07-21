using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{

    class Door
    {
        private string color;
        public Door()
        {

        }

        public Door(string color)
        {
            this.color = color;
        }

        public void setColor(string color)
        {
            this.color = color;
        }

        public string getColor()
        {
            return color;
        }

        public override string ToString()
        {
            return "I am a door, my color is " + color;
        }

    }

    class Person
    {
        private string name;
        private House home;
        public Person()
        {
            name = "";
            home = null;
        }

        public Person(string name)
        {
            this.name = name;
        }

        public Person (string name, House home)
        {
            this.name = name;
            this.home = home;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public void setHome(House home)
        {
            this.home = home;
        }

        public House getHouse()
        {
            return home;
        }

        public override string ToString()
        {
            return name + " " + home.ToString();
        }

    }


    class House
    {
        private int area;
        private List<Person> person;
        private Door door;

        public House()
        {

        }

        public House(int area)
        {
            this.area = area;
        }

        public House(int area, Person person, Door door)
        {
            this.area = area;
            this.door = door;
            this.person.Add(person);
        }

        public List<Person> getPeople()
        {
            return person;
        }

        public override string ToString()
        {
            return "I am a house, my area is " + area + " square feet";
        }

    }
}
