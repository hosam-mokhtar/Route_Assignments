using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using System.Text.RegularExpressions;
using static Linq.ListGenerator;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Assignment 01 LINQ
            //Note: Use ListGenerators.cs & Customers.xml

            #region LINQ - Element Operators
            //1.Get first Product out of Stock

            //2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.

            //3.Retrieve the second number greater than 5
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #endregion

            #region  LINQ - Aggregate Operators

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //1.Uses Count to get the number of odd numbers in the array

            //2.Return a list of customers and how many orders each has.

            //3.Return a list of categories and how many products each has

            //4.Get the total of the numbers in an array.

            //5.Get the total number of characters of all words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).

            //6.Get the length of the shortest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).

            //7.Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).

            //8.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).

            //9.Get the total units in stock for each product category.

            //10.Get the cheapest price among each category's products

            //11.Get the products with the cheapest price in each category(Use Let)

            //12.Get the most expensive price among each category's products.

            //13.Get the products with the most expensive price in each category.

            //14.Get the average price of each category's products.

            #endregion

            #region LINQ - Ordering Operators

            //1.Sort a list of products by name

            //2.Uses a custom comparer to do a case -insensitive sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //3.Sort a list of products by units in stock from highest to lowest.

            //4.Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            //string[] Arr = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};


            //5.Sort first by-word length and then by a case -insensitive sort of the words in an array.
            // String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //6.Sort a list of products, first by category, and then by unit price, from highest to lowest.

            //7.Sort first by-word length and then by a case -insensitive descending sort of the words in an array.
            //String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            //string[] Arr = {“zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine”};


            #endregion

            #region LINQ – Transformation Operators
            //1.Return a sequence of just the names of a list of products.

            //2.Produce a sequence of the uppercase and lowercase versions of each word in the original array(Anonymous Types).
            //tring[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //3.Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

            //4.Determine if the value of int in an array matches their position in the array.
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //2.Produce a sequence of the uppercase and lowercase versions of each word in the original array(Anonymous Types).
            //tring[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //5.Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //6.Select all orders where the order total is less than 500.00.

            //7.Select all orders where the order was made in 1998 or later.

            #endregion
        }
    }
}
