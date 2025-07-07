using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Drawing;

namespace Assignment_4_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            #region    6 - Write a program that allows the user to insert an integer then print all numbers between 1 to that number.

            while (true)
            {
                Console.Write("Enter Number: ");
                string s = Console.ReadLine();
                bool isNumber = int.TryParse(s, out int value);

                if (isNumber)
                {
                    for (int i = 1; i <= value; i++)
                    {
                        Console.Write(i);
                        if (i < value)
                            Console.Write(", ");
                    }
                    Console.WriteLine();
                    break;
                }
            }
            #endregion

            #region 7 - Write a program that allows the user to insert an integer then print a multiplication table up to 12.

            Console.Write("Enter Number: ");
            int n  = int.Parse(Console.ReadLine());

                for (int i = 1; i <= 12; i++)
                {
                    Console.Write(n*i + " ");
                }
            Console.WriteLine();

            #endregion

            #region  8 - Write a program that allows to user to insert number then print all even numbers between 1 to this number.

            Console.Write("Enter Number: ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 2; i <= num; i++)
            {
                if(i % 2 == 0)
                Console.Write(i + " ");
            }
            Console.WriteLine();

            #endregion

            #region  9 - Write a program that takes two integers then prints the power.

            Console.Write("Enter Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter Power: ");
            int power = int.Parse(Console.ReadLine());

            int originNumber = number;

            for (int i = 2; i <= power; i++)
            {
                number *= originNumber;
            }

            Console.WriteLine(number);

            #endregion

            #region  10 - Write a program to enter marks of five subjects and calculate total, average and percentage.

            int[] arr = new int[5];
            int total = 0;
            int average = 0;
            int percentage = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter Mark {i + 1}: ");
                arr[i]=int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < arr.Length; i++)
            {
                total += arr[i];

            }

            Console.WriteLine("Total Marks:" + total);
            Console.WriteLine("Average Marks:" + total/arr.Length);
            Console.WriteLine("Percentage:" + total / arr.Length + '%');

            #endregion

            #region  11 - Write a program to input the month number and print the number of days in that month.

            Console.Write("Month Numbe: ");
            int monthNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"Days in Month: {DateTime.DaysInMonth(2025,monthNumber)}");

            #endregion

            #region  12 - Write a program to create a Simple Calculator.
          
            while (true)
            {
              line:

                Console.WriteLine("1-Addition");
                Console.WriteLine("2-Subtraction");
                Console.WriteLine("3-Multiplication");
                Console.WriteLine("4-Division");
                Console.WriteLine("5-Exist");

                int operation = int.Parse(Console.ReadLine());
                if (operation == 5)
                    break;
                else if (operation < 1 || operation > 5)
                    goto line;

                Console.WriteLine("Enter number 1: ");
                int num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number 2: ");
                int num2 = int.Parse(Console.ReadLine());

                    if (operation == 1)
                        Console.WriteLine($"Addition = {num1 + num2}");
                    else if (operation == 2)
                        Console.WriteLine($"Subtraction = {num1 - num2}");
                    else if (operation == 3)
                        Console.WriteLine($"Multiplication = {num1 * num2}");
                    else if (operation == 4)
                        Console.WriteLine($"Division = {num1 / num2}");


                Console.WriteLine("-----------------------------------------");           
                }



            #endregion

            #region  13 - Write a program to allow the user to enter a string and print the REVERSE of it.

                           Console.WriteLine("Enter a String: ");
                           string s = Console.ReadLine();
                           StringBuilder sb = new StringBuilder(s);

                           for (int i = 0; i < sb.Length / 2; i++)
                           {
                               (sb[i], sb[sb.Length - 1 - i]) = (sb[sb.Length - 1 - i], sb[i]);         
                           }

                           Console.WriteLine(sb);

            #endregion

               #region  14 - Write a program to allow the user to enter int and print the REVERSED of it.

               Console.WriteLine("Enter an Integer: ");
               int n = int.Parse(Console.ReadLine());
               int result = 0;

               while (n > 0) {
                   int ans = n % 10;
                   result = (result * 10) +  ans;     
                   n /= 10;
               }

               Console.WriteLine($"result: {result}");

               // or
               // Convert integer number to string, reverse it and convert to integer

               #endregion
  
            #region  15 - Write a program in C# Sharp to find prime numbers within a range of numbers.

            Console.Write("Input starting number of range: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Input ending number of range: ");
            int end = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = start; i <= end; i++)
            {
                bool isprime = true;
                double sqrt = Math.Sqrt(i);

                for (int j = 2; j <= sqrt; j++)
                {
                    if (i % j == 0)
                    {
                        isprime = false;
                        break;
                    }
                }

                if (isprime && i >= 2)
                    list.Add(i);
            }

            Console.Write($"The prime number between {start} and {end} are: ");

            for (int i = 0; i < list.Count; i++) {

                Console.Write($"{list[i]} ");
            }

            #endregion
 
           #region  17 - Create a program that asks the user to input three points(x1, y1), (x2, y2), and(x3, y3), and determines whether these points lie on a single straight line.

            int[,] points = new int [3,2];
            double[] slope = new double[2];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter Point X{i + 1}: ");
                points[i, 0] = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter Point Y{i + 1}: ");
                points[i, 1] = int.Parse(Console.ReadLine());
            }

            slope[0] = (double)(points[1, 1] - points[0, 1]) / (points[1, 0] - points[0, 0]);
            slope[1] = (double)(points[2, 1] - points[0, 1]) / (points[2, 0] - points[0, 0]);

            if (Math.Abs(slope[0] - slope[1]) < 1e-6)
                Console.WriteLine("single straight line.");
            else
                Console.WriteLine("not single straight line");


            #endregion
            
                #region  18 - Within a company, the efficiency of workers is evaluated based on the duration required to complete a specific task.

                            /*  A worker's efficiency level is determined as follows: 
                              -If the worker completes the job within 2 to 3 hours, they are considered highly efficient.
                              - If the worker takes 3 to 4 hours, they are instructed to increase their speed.
                              - If the worker takes 4 to 5 hours, they are provided with training to enhance their speed.
                              - If the worker takes more than 5 hours, they are required to leave the company.
                                To calculate the efficiency of a worker, the time taken for the task is obtained via user input from the keyboard.
                            */

                        Console.WriteLine("Enter Hours: ");
                        bool isValid = double.TryParse(Console.ReadLine(), out double hours);

                        if (isValid)
                        {
                            if (hours <= 0)
                                Console.WriteLine("Not Valid Input");
                            else if (hours <= 2 && hours <= 3)
                                Console.WriteLine("highly efficient");
                            else if (hours >= 2 && hours <= 3)
                                Console.WriteLine("highly efficient");
                            else if (hours > 3 && hours <= 4)
                                Console.WriteLine("instructed to increase their speed");
                            else if (hours > 4 && hours <= 5)
                                Console.WriteLine("training to enhance their speed");
                            else if (hours > 5)
                                Console.WriteLine("required to leave the company");
                        }

                        #endregion
            
            }
    }
}
