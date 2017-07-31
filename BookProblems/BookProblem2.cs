using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    /// <summary>
    /// mod first program to display how many times that number eixsts
    /// </summary>
    class BookProblem2
    {
        List<int> numbers;
        const int count = 10;
        public BookProblem2()
        {
            numbers = new List<int>();
        }

        public void get()
        {
            getInput();
            harassUser();
        }
        private void getInput()
        {
            int input = 0;
            while (numbers.Count < 10)
            {
                Console.WriteLine("Please enter a whole number:");
                try { input = Convert.ToInt32(Console.ReadLine()); }
                catch
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                    continue;
                }
                numbers.Add(input);
            }
        }
        private void harassUser()
        {
            Console.WriteLine("Please enter a final number:");
            int input = 0;
            try { input = Convert.ToInt32(Console.ReadLine()); }
            catch
            {
                Console.WriteLine("Invalid entry");
                harassUser();
                return;
            }
            if (numbers.Contains(input)) {
                int c = 0;
                for (int i = 0; i < numbers.Count; i++) { if(numbers[i] == input) { c++; } }
                Console.WriteLine("The number " + input + " exists " + c + " times."); }
            else { Console.WriteLine("The number " + input + " does not exist."); }
        }
    }

}

