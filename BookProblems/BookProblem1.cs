﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    //Enter 10 numbers
    //Store in array
    //Get one additional number from user
    //Check array for that number already existing
    //display message if / not that number exists
    class BookProblem1
    {
        List<int> numbers;
        const int count = 10;
        public BookProblem1()
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
            while (numbers.Count < 10) {
                Console.WriteLine("Please enter a whole number:");
                try { input = Convert.ToInt32(Console.ReadLine()); }
                catch {
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
            if (numbers.Contains(input)) { Console.WriteLine("The number " + input + " exists."); }
            else { Console.WriteLine("The number " + input + " does not exist."); }
        }
    }
}

