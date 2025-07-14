using System.Buffers.Text;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.IO.Pipelines;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Assignment_6_C_
{
    internal class Program
    {
        static public int modifyValue(int n)
        {
            n = 20;
            return n;
        }
        static public int modifyReference(ref int n)
        {
            n = 20;
            return n;
        }

        static public int[] modifyArrayValues(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += 100;
            }
            arr = new int[] { 1, 2, 3 };
            return arr;
        }
        static public int[] modifyArrayReferences(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += 100;
            }
            arr = new int[] { 1, 2, 3 };
            return arr;
        }
        static public void summationAdnSubtracting(int num1, int num2, out int sum, out int sub)
        {
            sum = num1 + num2;
            sub = num1 - num2;
        }
        static public int calculateSumOfIndividualDigits(int num)
        {
            if (num < 0)
                num *= -1;

            int result = 0;

            while (num > 0)
            {
                int ans = num % 10;
                num /= 10;
                result += ans;
            }

            return result;
        }
        static public bool isPrime(int n)
        {
            if (n < 2) return false;

            double sqrt = Math.Sqrt(n);
            for (int i = 2; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static public void minMaxArray(int[] nums, ref int min, ref int max)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if(min > nums[i])
                    min = nums[i];
                if(max < nums[i])
                    max = nums[i];
            }
        }

        static public int factorial(int n)
        {
            if(n < 0) 
                throw new ArgumentException("Don't input negative value");

            int result = 1;

            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        static public void changeChar(string s, int index, char newChar)
        {
            if (index < 0 || index >= s.Length || string.IsNullOrEmpty(s))
                throw new ArgumentException("Invalid inputs");

            StringBuilder sb = new StringBuilder(s);

            sb[index] = newChar;

            Console.WriteLine($"New String: { sb.ToString()}");
        }
        static void Main(string[] args)
        {

            #region   1 - Explain the difference between passing(Value type parameters) by value and by reference then write a suitable c# example.

            /*
            Passing by Value

            A copy of the variable is passed to the method.
            Changes made inside the method do not affect the original variable outside.
            --------------------------------------------------------------------------------------------
            Passing by Reference (ref keyword)

            The actual variable(not a copy) is passed to the method.
            Changes inside the method do affect the original variable.
            */

            //int x = 10;

            //modifyValue(x);
            //Console.WriteLine(x);              // 10 

            //modifyReference(ref x);
            //Console.WriteLine(x);              // 20


            #endregion

            #region   2 - Explain the difference between passing(Reference type parameters) by value and by reference then write a suitable c# example.

            /*
            Passing Reference Type By Value(Default)

            A copy of the reference is passed to the method.
            The method can modify the contents of the object.
            But it cannot replace the object itself(i.e., change the reference outside the method).
            --------------------------------------------------------------------------------------------
            Passing Reference Type By Reference(ref keyword)

            A reference to the reference is passed.
            The method can:
            Modify the contents of the object
            Replace the object entirely
            */


            //int[] array = { 10, 20, 30, 40, 50 };

            //modifyArrayValues(array);            // 110, 120, 130, 140, 150
            //foreach (int i in array)
            //    Console.WriteLine(i);

            //modifyArrayReferences(ref array);    // 1,   2,   3
            //foreach (int i in array)
            //    Console.WriteLine(i);

            #endregion

            #region    3 - Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers

            //Console.WriteLine("Enter Number 1: ");
            //int num1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter Number 2: ");
            //int num2 = int.Parse(Console.ReadLine());

            //int sum;
            //int sub;

            //summationAdnSubtracting(num1, num2, out sum, out sub);
            //Console.WriteLine($"Sum = {sum}");
            //Console.WriteLine($"Sub = {sub}");

            #endregion

            #region      4 - Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.
            /* 
            Output should be like
            Enter a number: 25
            The sum of the digits of the number 25 is: 7  
            */

              //  Console.WriteLine("Enter Integer Number: ");
              //  Console.WriteLine($"Sum of Individual Digits = {calculateSumOfIndividualDigits(int.Parse(Console.ReadLine()))}");

            #endregion

            #region      5 - Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not:

            //   Console.WriteLine("Enter Integer Number: ");           
            //   Console.WriteLine(isPrime(int.Parse(Console.ReadLine())));

            #endregion

            #region      6 - Create a function named MinMaxArray, to return the minimum and maximum values stored in an array, using reference parameters

            //int[] arr = { 50, 40 ,80, 60, 40, 10, 60, 20 };
            //int min = int.MaxValue;
            //int max = int.MinValue;

            //minMaxArray(arr, ref min, ref max);

            //Console.WriteLine($"Min = {min}");
            //Console.WriteLine($"Max = {max}");

            #endregion

            #region      7 - Create an iterative(non-recursive) function to calculate the factorial of the number specified as 

            //    Console.WriteLine("Enter Integer Number: ");
            //    Console.WriteLine(factorial(int.Parse(Console.ReadLine())));

            #endregion

            #region 8 - Create a function named "ChangeChar" to modify a letter in a certain position(0 based) of a string, replacing it with a different letter

            //Console.WriteLine("Enter a String: ");
            //string word = Console.ReadLine();

            //Console.WriteLine("Enter a Index: ");
            //int index = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter a Charcacter: ");
            //char newChar = char.Parse(Console.ReadLine());

            //changeChar(word, index, newChar);

            #endregion
        }
    }
}
