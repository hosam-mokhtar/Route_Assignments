using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region  1.The Bubble Sort algorithm has a time complexity of O(n ^ 2) 
            //in its worst and average cases, which makes it inefficient for large datasets. 
            //How we can optimize the Bubble Sort algorithm
            //And implement the code of this optimized bubble sort algorithm

            //int[] numbers = { 10, 20, 13, 41, 50, 66, 7, 8, 5};
            //OptimizedBubbleSort(numbers);

            //foreach (var i in numbers)
            //    Console.Write($"{i}  ");

            //Console.WriteLine('\n' + new string('-',40));

            //string[] names = ["Route", "Radwa", "Nada", "Hossam"];
            //OptimizedBubbleSort(names);

            //foreach (var i in names)
            //    Console.Write($"{i}  ");

            #endregion

            #region  2.create a generic Range < T > class that represents a range of values 
            //from a minimum value to a maximum value.The range should support basic operations 
            //such as checking if a value is within the range and determining the length of the range.
            //Requirements:
            //1.Create a generic class named Range<T> where T represents the type of values.
            //2.Implement a constructor that takes the minimum and maximum values to define the range.
            //3.Implement a method IsInRange(T value) that returns true if the given  value is within the range, otherwise false.
            //4.Implement a method Length() that returns the length of the range (the difference between the maximum and minimum values).
            //5.Note: You can assume that the type T used in the Range<T> class implements the IComparable<T> interface to allow for comparisons.

            //int x = 10;
            //int y = 22;
            //var rangeIntegers = new Range<int>(x,y);
            //var rangeIntegers2 = new Range<int>(15,21);

            //Console.WriteLine($"{10} is in Range? {rangeIntegers.IsInRange(10)}");
            //Console.WriteLine($"{5} is in Range? {rangeIntegers.IsInRange(5)}");
            //Console.WriteLine($"{12} is in Range? {rangeIntegers.IsInRange(12)}");

            //Console.WriteLine($"{x}-{y} is Difference? {rangeIntegers.Length()}");

            //Console.WriteLine($"{rangeIntegers.Minimum} Compare to {rangeIntegers2.Minimum}? {rangeIntegers.Minimum.CompareTo(rangeIntegers2.Minimum)}");
            //Console.WriteLine($"{rangeIntegers.Maximum} Compare to {rangeIntegers2.Maximum}? {rangeIntegers.Maximum.CompareTo(rangeIntegers2.Maximum)}");
            //Console.WriteLine($"{rangeIntegers} Compare to {rangeIntegers2}? {rangeIntegers.CompareTo(rangeIntegers2)}");

            //Console.WriteLine(new string('-', 40));

            //string s1 = "Hossam";
            //string s2 = "Radwa";
            //var rangeNames = new Range<string>(s1, s2);

            //Console.WriteLine($"{s1}-{s2} is Difference? {rangeNames.Length()}");

            #endregion
        }
        static public T[] OptimizedBubbleSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool isSwapped = false;

                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j + 1].CompareTo(arr[j]) < 0)
                    {
                        (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);
                        isSwapped = true;
                    }
                }

                if (!isSwapped)
                    break;
            }

            return arr;
        }
    }
}
