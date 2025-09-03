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
using static Linq.Order;
using System.Linq;
using System;

namespace Linq
{
    internal class Program
    {
        class CaseInsensitiveComparer : IComparer<string>
        {
            public int Compare(string? x, string? y)
            {
                if (ReferenceEquals(x, y)) return 0; 
                if (x is null) return -1;            
                if (y is null) return 1;       
                return string.Compare(x,y,StringComparison.OrdinalIgnoreCase);
            }
        }

        static void PrintResult(dynamic result)
        {
            foreach (var item in result)
                Console.WriteLine(item);
        }
        static void Main(string[] args)
        {
            //Assignment 01 LINQ
            //Note: Use ListGenerators.cs & Customers.xml

            #region LINQ - Element Operators
            //1.Get first Product out of Stock
            //{
            //var res = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            //Console.WriteLine(res);
            //}

            //2.Return the first product whose Price > 1000,
            //unless there is no match, in which case null is returned.
            //{
            //var res = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            //Console.WriteLine(res);
            //}

            //3.Retrieve the second number greater than 5
            //{
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res = Arr.Where(n => n > 5).Take(2).Last();
            //Console.WriteLine(res);
            //}
            #endregion

            #region  LINQ - Aggregate Operators

            //1.Uses Count to get the number of odd numbers in the array
            //{
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res = Arr.Count(p => p % 2 == 1);
            //Console.WriteLine(res);
            //}

            //2.Return a list of customers and how many orders each has.
            //{
            //var res = from c in CustomerList
            //          select new
            //             {
            //                 CustomerID = c.CustomerID,
            //                 OrdersCount = c.Orders.Count()
            //             };
            //   PrintResult(res);
            //}

            //3.Return a list of categories and how many products each has
            //{
            //var res = from p in ProductList
            //              //where p.UnitsInStock > 0    //this line if you have UnitsInStock Only
            //          group p by p.Category
            //     into Categories
            //          let totalUnits = Categories.Count()
            //          select new
            //          {
            //              Category = Categories.Key,
            //              Total_Units = totalUnits
            //          };
            //PrintResult(res);
            //}

            //4.Get the total of the numbers in an array.
            //{
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res = Arr.Sum();
            //Console.WriteLine(res);
            //}

            //string[] words = File.ReadAllLines("dictionary_english.txt");

            //5.Get the total number of characters of all words in dictionary_english.txt
            //(Read dictionary_english.txt into Array of String First).
            //{
            //int totalChars = words.Sum(w => w.Length);
            //Console.WriteLine(totalChars);
            //}

            //6.Get the length of the shortest word in dictionary_english.txt
            //(Read dictionary_english.txt into Array of String First).
            //{
            //int minWord = words.Min(w => w.Length);
            //Console.WriteLine(minWord);
            //}

            //7.Get the length of the longest word in dictionary_english.txt
            //(Read dictionary_english.txt into Array of String First).
            //{
            //int maxWord = words.Max(w => w.Length);
            //Console.WriteLine(maxWord);
            //}

            //8.Get the average length of the words in dictionary_english.txt
            //(Read dictionary_english.txt into Array of String First).
            //{
            //double avgLenOfWord = words.Average(w => w.Length);
            //Console.WriteLine(avgLenOfWord);
            //}

            //9.Get the total units in stock for each product category.
            //{
            //var res = from p in ProductList
            //          where p.UnitsInStock > 0
            //          group p by p.Category
            //     into Categories
            //          let totalUnitsInStock = Categories.Count()
            //          select new
            //          {
            //              Category = Categories.Key,
            //              Total_Units = totalUnitsInStock
            //          };
            //PrintResult(res);
            //}

            //10.Get the cheapest price among each category's products
            //{
            //var res = ProductList.Min(p => p.UnitPrice);
            //Console.WriteLine(res);
            //}

            //11.Get the products with the cheapest price in each category(Use Let)
            //{
            //var res = from p in ProductList
            //          where p.UnitsInStock > 0
            //          group p by p.Category 
            //     into Categories
            //     let minPrice = Categories.Min(p => p.UnitPrice)
            //          select new
            //          {
            //              Category = Categories.Key,
            //              Min_Price = minPrice
            //          };
            //PrintResult(res);
            //}

            //12.Get the most expensive price among each category's products.
            //{
            //var res = ProductList.Max(p => p.UnitPrice);
            //Console.WriteLine(res);
            //}

            //13.Get the products with the most expensive price in each category.
            //{
            //var res = from p in ProductList
            //          where p.UnitsInStock > 0
            //          group p by p.Category
            //     into Categories
            //          select new {
            //                       Category = Categories.Key,
            //                       Expensive_Price = Categories.Max(p => p.UnitPrice)
            //                     };
            //PrintResult(res);
            //}

            //14.Get the average price of each category's products.
            //{
            //var res = from p in ProductList
            //          where p.UnitsInStock > 0
            //          group p by p.Category
            //     into Categories
            //          select new {
            //                       Category = Categories.Key,
            //                       Average_Price = Math.Round(Categories.Average(p => p.UnitPrice),2)
            //                     };
            //PrintResult(res);
            //}

            #endregion

            #region LINQ - Ordering Operators

            //1.Sort a list of products by name
            //{
            //var res = ProductList.OrderBy(p => p.ProductName);
            //PrintResult(res);
            //}

            //2.Uses a custom comparer to do a case -insensitive sort of the words in an array.
            //{
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            ////First Solution:
            //var res = Arr.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            //PrintResult(res);
            //Console.WriteLine("---------------------");
            ////Second Solution:
            //var res2 = Arr.OrderBy(w => w, new CaseInsensitiveComparer());
            //PrintResult(res2);
            //}

            //3.Sort a list of products by units in stock from highest to lowest.
            //{
            //var res = ProductList.OrderByDescending(p => p.UnitsInStock);
            //PrintResult(res);
            //or
            //var res = ProductList.OrderBy(p => p.UnitsInStock).Reverse();
            //PrintResult(res);
            //}

            //4.Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            //{
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            //var res = Arr.OrderBy(p => p.Length).ThenBy(name => name);
            //PrintResult(res);
            //}

            //5.Sort first by-word length and then by a case -insensitive sort of the words in an array.
            //{
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var res = Arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            //PrintResult(res);
            //}

            //6.Sort a list of products, first by category, and then by unit price, from highest to lowest.
            //{
            //var res = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            //PrintResult(res);
            //}

            //7.Sort first by-word length and then by a case -insensitive descending sort of the words in an array.
            //{
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var res = Arr.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            //PrintResult(res);
            //}

            //8.Create a list of all digits in the array whose second letter is 'i'
            //that is reversed from the order in the original array.
            //{
            //string[] Arr = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            //var res = Arr.Where(w => w[1] == 'i').Reverse();
            //PrintResult(res);
            //}

            #endregion

            #region LINQ – Transformation Operators
            //1.Return a sequence of just the names of a list of products.
            //{
            //var result = ProductList.Select(p => p.ProductName);
            //PrintResult(result);
            //}

            //2.Produce a sequence of the uppercase and lowercase versions of each word in the original array
            //(Anonymous Types).
            //{
            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            //var res = words.Select(w => new
            //{
            //    Upper = w.ToUpper(),
            //    Lower = w.ToLower()
            //});
            //PrintResult(res);
            //}

            //3.Produce a sequence containing some properties of Products,
            //including UnitPrice which is renamed to Price in the resulting type.
            //{
            //var res = ProductList.Select(p => new {p.ProductID, p.ProductName, Price = p.UnitPrice });
            //PrintResult(res);
            //}

            //4.Determine if the value of int in an array matches their position in the array.
            //{
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res = Arr.Select((index, value) => new
            //{
            //   Position = index,
            //   Value = value == index,
            //});
            //foreach (var item in res)
            //    Console.WriteLine($"{item.Position}:{item.Value}");
            //}

            //5.Returns all pairs of numbers from both arrays such that the number
            //from numbersA is less than the number from numbersB.
            //{
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };
            //var pairs = numbersA.SelectMany(
            //                                 a => numbersB.Where(b => a < b),
            //                                 (a, b) => new { A = a, B = b }
            //                               );
            //foreach (var pair in pairs)
            //    Console.WriteLine($"{pair.A} is less than {pair.B}");
            //}

            //6.Select all orders where the order total is less than 500.00.
            //{
            //var res = from c in CustomerList
            //          from o in c.Orders
            //          where o.Total < 500.00m
            //          select o;
            //PrintResult(res);
            //}

            //7.Select all orders where the order was made in 1998 or later.
            //{
            //var res = from c in CustomerList
            //          from o in c.Orders
            //          where o.OrderDate.Year >= 1998
            //          select o;
            //PrintResult(res);
            //}

            #endregion
        }
    }
}
