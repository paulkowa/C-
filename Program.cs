using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CA1
{
    public class Program
    {
        private bool checkValid(string s)
        {
            if (s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(s.ElementAt(i) > 47 && 58 > s.ElementAt(i)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void seperateLines()
        {
            int total = 0;
            for (int z = 0; z < 3; z++)
            {
                string input = Console.ReadLine();
                total += Convert.ToInt32(input);
            }
            Console.WriteLine(total);
        }

        private double salesTax()
        {
            double tax = 0.06;
            Console.WriteLine("Enter the amount of the sale");
            double sale = Convert.ToDouble(Console.ReadLine());
            return (sale * tax) + sale;

        }

        private void switchEx()
        {
            Console.WriteLine("Please enter a number between 1 and 5");
            string s = Console.ReadLine();

            switch(s)
            {
                case "1":
                    Console.WriteLine("One");
                    break;
                case "2":
                    Console.WriteLine("One");
                    break;
                case "3":
                    Console.WriteLine("One");
                    break;
                case "4":
                    Console.WriteLine("One");
                    break;
                case "5":
                    Console.WriteLine("One");
                    break;
                default:
                    Console.WriteLine("Invalid value, please try again");
                    switchEx();
                    return;
            }
        }

        private void PayCalc()
        {
            Console.WriteLine("Enter your hourly pay rate:");
            double rate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter number of hours worked:");
            double hours = Convert.ToDouble(Console.ReadLine());

            if (hours <= 40.0)
            {
                Console.WriteLine(rate * hours);
            }
            else
            {
                double ot = hours - 40.0;
                hours = hours - ot;
                Console.WriteLine((rate * hours) + ((rate * 1.5) * ot ));
            }
        }

        private void increasingNumbers()
        {
            int[] i = new int[3];

            for(int x = 0; x < 3; x++)
            {
                Console.WriteLine("Enter an integer:");
                i[x] = Convert.ToInt32(Console.ReadLine());
            }
            
            if(i[0] < i[1] && i[1] < i[2])
            {
                Console.WriteLine("True");
                return;
            }

            Console.WriteLine("False");
        }

        private void TempConversion()
        {
            Console.WriteLine("Enter a temperature:");
            double temp = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Indicate F for Fahrenheit or C for Celsius");
            string s = Console.ReadLine();
            
            if(s.Equals("F") || s.Equals("f"))
            {
                Console.WriteLine(((5.0 / 9.0) * (temp - 32)) + "C");
                return;
            }

            else if(s.Equals("C") || s.Equals("c"))
            {
                Console.WriteLine(((9.0 / 5.0) * temp + 32) + "F");
                return;
            }
            else
            {
                Console.WriteLine("Invalid entry");
            }
        }

        private void highLow()
        {
            Random rand = new Random();
            int i = rand.Next(1, 100);
            Console.WriteLine("Guess my number:");
            int guess = Convert.ToInt32(Console.ReadLine());

            while (guess != i)
            {
                if (guess > i) { Console.WriteLine("Too high"); }
                else { Console.WriteLine("Too low"); }
                Console.WriteLine("Guess my number:");
                guess = Convert.ToInt32(Console.ReadLine());
            }
            
            Console.WriteLine("Correct!");
        }

        private void Change()
        {
            int quarter, dime, nick, penny;
            string s;
            quarter = dime = nick = penny = 0;

            Console.WriteLine("Enter a number between 1 and 99:");
            s = Console.ReadLine();
            if (s.Equals("")) { return; }
            if (!checkValid(s)) { return; }

            int num = Convert.ToInt32(s);
            if(num > 99 || 0 > num)
            {
                Console.WriteLine("Incorrect value");
                Change();
            }

            else
            {
                while(num > 0)
                {
                    if((num - 25) >= 0) {
                        num = num - 25;
                        quarter++;
                    }
                    else if ((num - 10) >= 0) {
                        num = num - 10;
                        dime++;
                    }
                    else if ((num - 5) >= 0) {
                        num = num - 5;
                        nick++;
                    }
                    else if ((num - 1) >= 0) {
                        num = num - 1;
                        penny++;
                    }
                }

                Console.WriteLine("Change is " + quarter + " quarters, " + dime + " dimes, " + nick + " nickles, and " + penny + " pennies.");
            }
        }

        private void bmi()
        {
            Console.WriteLine("Enter your height in inches:");
            double height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter your weight in pounds:");
            double weight = Convert.ToDouble(Console.ReadLine());

            if (height > 110.0 || weight > 1450.0)
            {
                Console.WriteLine("Invalid Entry, please try again.");
                bmi();
                return;
            }

            double output = weight*703.0/(height*height);
            
            if (output < 18.5) { Console.WriteLine("Underweight."); }
            else if (output >= 18.5  && output < 25.0) { Console.WriteLine("Normal."); }
            else if (output >= 25.0 && output < 30.0) { Console.WriteLine("Overweight."); }
            else if (output >= 30.0) { Console.WriteLine("Obese."); }

        }

        private void fillArray(ArrayList input, int n)
        {
            Random rand = new Random(32);
            //Console.WriteLine(rand.Next(0, 1000));
            for (int i = 0; i < n; i++)
            {
                input.Add(rand.Next(0, 1000));
            }
        }

        private void printArray(ArrayList input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                Console.Write(input[i] + " ");
            }
            Console.Write('\n');
        }

       
        private void marginalTax()
        {
            Console.WriteLine("Please enter your income, as a continous integer:");
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input.Equals("") || input.Equals(null)) {
                    Console.WriteLine("Taxation is theft.");
                    return;
                }
                else if (!checkValid(input)) { Console.WriteLine("Invalid Entry. Please try again."); }
                else if(checkValid(input))
                {
                    decimal income = Convert.ToDecimal(input);
                    decimal total = 0;

                    if(income > 91900)
                    {
                        Console.WriteLine("You make too much money.");
                        return;
                    }
                    else if (income > 39950m)
                    {
                        decimal t = income - 39950m;
                        total = ((t * 0.25m) + 5526.25m);
                    }
                    else if (income > 9325m && income < 39951m)
                    {
                        decimal t = income - 9325m;
                        total = ((t * 0.15m) + 932.5m);
                    }

                    else
                    {
                        total = income * 0.1m;
                    }
                    Console.WriteLine("Your tax total is: " + total);
                    Console.WriteLine("Please enter your income, as a continous integer:");
                }

            }
        }

        private void swap(ref ArrayList input, int i, int j)
        {
            var temp = input[i];
            input[i] = input[j];
            input[j] = temp;
        }

        private void quickSort(ref ArrayList input, int left, int right)
        {
            int end, pivot;
            end = pivot = right;
            int start = left;

            while (left != right)
            {
                if (right == pivot)
                {
                    if ((int)input[left] >= (int)input[pivot])
                    {
                        swap(ref input, left, pivot);
                        pivot = left;
                    }
                    else { left++; }
                }
                else
                {
                    if((int)input[right] < (int)input[pivot])
                    {
                        swap(ref input, right, pivot);
                        pivot = right;
                    }
                    else { right--; }
                }
            }
            if(pivot != start) { quickSort(ref input, start, pivot - 1); }
            if(pivot != end) { quickSort(ref input, pivot + 1, end); }

        }

        private void dateTime()
        {
            Console.WriteLine("Enter your birthday as mm/dd/yyyy");
            string input = Console.ReadLine();
            string[] split = new string[3];
            if (input.Length > 0) { split = input.Split('/'); }
            if (split.Length == 3)
            {
                if (Convert.ToInt32(split.GetValue(2)) > 0 && Convert.ToInt32(split.GetValue(2)) < 10000 && Convert.ToInt32(split.GetValue(0)) > 0 && Convert.ToInt32(split.GetValue(0)) < 13 && Convert.ToInt32(split.GetValue(1)) > 0 && Convert.ToInt32(split.GetValue(1)) < 32)
                {
                    DateTime bd = new DateTime(Convert.ToInt32(split.GetValue(0)), Convert.ToInt32(split.GetValue(0)), Convert.ToInt32(split.GetValue(0)));
                    if (bd.DayOfYear > DateTime.Now.DayOfYear)
                    {
                        DateTime lbd = new DateTime(DateTime.Now.Year - 1, Convert.ToInt32(split.GetValue(0)), Convert.ToInt32(split.GetValue(1)));
                        DateTime nbd = new DateTime(DateTime.Now.Year, Convert.ToInt32(split.GetValue(0)), Convert.ToInt32(split.GetValue(1)));
                        Console.WriteLine("Your next Birthday is " + (nbd - DateTime.Now).Days + " days away.");
                        Console.WriteLine("Your last Birthday was " + (DateTime.Now - lbd).Days + " days ago.");
                    }

                    else
                    {
                        DateTime lbd = new DateTime(DateTime.Now.Year, Convert.ToInt32(split.GetValue(0)), Convert.ToInt32(split.GetValue(1)));
                        DateTime nbd = new DateTime(DateTime.Now.Year + 1, Convert.ToInt32(split.GetValue(0)), Convert.ToInt32(split.GetValue(1)));
                        Console.WriteLine("Your next Birthday is " + (nbd - DateTime.Now).Days + " days away.");
                        Console.WriteLine("Your last Birthday was " + (DateTime.Now - lbd).Days + " days ago.");
                    }
                }
            }
        }

        private void calculator()
        {
            Console.WriteLine("Enter first number:");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int j = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter operator");
            char k = Convert.ToChar(Console.ReadLine());

            switch (k)
            {
                case '+':
                    Console.WriteLine(i + j);
                    break;
                case '-':
                    Console.WriteLine(i - j);
                    break;
                case '*':
                    Console.WriteLine(i * j);
                    break;
                case '/':
                    Console.WriteLine(i / j);
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    return;
            }
        }

        private void calculator2()
        {
            Console.WriteLine("Enter two numbers and then an operator, seperated by spaces:");
            string[] input = Console.ReadLine().Split(' ');
            int i = Convert.ToInt32(input[0]);
            int j = Convert.ToInt32(input[1]);
            char k = Convert.ToChar(input[2]);

            switch (k)
            {
                case '+':
                    Console.WriteLine(i + j);
                    break;
                case '-':
                    Console.WriteLine(i - j);
                    break;
                case '*':
                    Console.WriteLine(i * j);
                    break;
                case '/':
                    Console.WriteLine(i / j);
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    return;
            }
        }

        private void lists()
        {
            List<string> strings = new List<string>();
            string cur = "";
            ConsoleKeyInfo c;

            do {
                c = Console.ReadKey();
                if(c.Key == ConsoleKey.Enter)
                {
                    if(cur.Length > 0) { strings.Add(cur); }
                    break;
                }
                else if(c.Key == ConsoleKey.Spacebar)
                {
                    strings.Add(cur);
                    cur = "";
                }
                else
                {
                    cur += c.Key.ToString();
                }

            } while (true);
            for (int i = 0; i < strings.Count; i++) { Console.Write(strings.ElementAt(i).ToLower() + " "); }
            Console.Write('\n');
            strings.Sort();
            for (int i = 0; i < strings.Count; i++) { Console.Write(strings.ElementAt(i).ToLower() + " "); }
            Console.Write('\n');
        }

        private void dictionaries()
        {
            Dictionary<string, string> input = new Dictionary<string, string>();
            ConsoleKeyInfo c;
            String key = "";
            bool running = true;

            while (running) { 
                Console.WriteLine("Enter a key, followed by a value seperated by a space");
                String cur = "";
            
                do
                {
                    int space = 0;
                    c = Console.ReadKey();
                    if (c.Key == ConsoleKey.Escape) { return; }
                    else if(c.Key == ConsoleKey.Enter) { break; }
                    else if (c.Key == ConsoleKey.Spacebar)
                    {
                        if(space == 0)
                        {
                            key = cur;
                            cur = "";
                            space++;
                        }

                        else
                        {
                            Console.WriteLine("Invalid entry.");
                            break;
                        }

                    }
                    else
                    {
                        cur += c.KeyChar;
                    }

                } while (true);
                input.Add(key, cur);
            }

        }

        private void car()
        {
            Car car = new Car(35, 10);
            car.drive(35);
            Console.WriteLine(car.checkTank());
        }

        private void home(int homes, int people)
        {
            List<House> h = new List<House>();

            for(int i = 0; i < homes; i++)
            {
                House k = new House();
                h.Add(k);
            }

            for(int i = 0; i < people; i++)
            {
                Person p = new Person(Convert.ToString(i));
                Random rand = new Random();
                h.ElementAt(rand.Next(0, homes - 1)).getPeople().Add(p);
            }

            //h.ElementAt(0).getPeople().ElementAt(0).ToString();
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            //ArrayList array = new ArrayList();
            //p.seperateLines();
            //p.switchEx();
            //p.PayCalc();
            //p.increasingNumbers();
            //p.TempConversion();
            //p.highLow();
            //p.Change();
            //p.bmi();
            //p.marginalTax();
            //p.dateTime();
            //p.calculator();
            //p.calculator2();
            //p.lists();
            //p.dictionaries();
            //p.car();
            //p.home(10, 10);


            //p.fillArray(array, 1000);
            //p.printArray(array);
            //Console.WriteLine(DateTime.Now.Millisecond);
            //p.quickSort(ref array, 0, array.Count - 1);
            //array.Sort();
            //Console.WriteLine(DateTime.Now.Millisecond);
            //p.printArray(array);
        }
    }
}
