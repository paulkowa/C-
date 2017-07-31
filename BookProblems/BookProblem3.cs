using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    /// <summary>
    /// write a program that stores the days of each month in an array
    /// ask the user for a number which is to represent a month
    /// return the number of days in that month
    /// </summary>
    class BookProblem3
    {
        List<int> days;
        public BookProblem3()
        {
            days = new List<int>();
            fillList(days);
        }

        public void get()
        {
            getInput(days);
        }

        private void fillList(List<int> day)
        {
            day.Add(31);
            day.Add(28);
            day.Add(31);
            day.Add(30);
            day.Add(31);
            day.Add(30);
            day.Add(31);
            day.Add(31);
            day.Add(30);
            day.Add(31);
            day.Add(30);
            day.Add(31);
        }
        private void getInput(List<int> day)
        {
            Console.WriteLine("Please enter a month.");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "january":
                    Console.WriteLine(day[0]);
                    break;
                case "february":
                    Console.WriteLine(day[1]);
                    break;
                case "march":
                    Console.WriteLine(day[2]);
                    break;
                case "april":
                    Console.WriteLine(day[3]);
                    break;
                case "may":
                    Console.WriteLine(day[4]);
                    break;
                case "june":
                    Console.WriteLine(day[5]);
                    break;
                case "july":
                    Console.WriteLine(day[6]);
                    break;
                case "august":
                    Console.WriteLine(day[7]);
                    break;
                case "september":
                    Console.WriteLine(day[8]);
                    break;
                case "october":
                    Console.WriteLine(day[9]);
                    break;
                case "november":
                    Console.WriteLine(day[10]);
                    break;
                case "december":
                    Console.WriteLine(day[11]);
                    break;
                default:
                    Console.WriteLine("Invalid entry. Please try again");
                    getInput(day);
                    break;

            }

        }
    }
}
