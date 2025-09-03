using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Linq.ListGenerators;

namespace Linq
{
    internal class Program
    {
        static void PrintResult(dynamic result)
        {
            foreach (var item in result)
                Console.WriteLine(item);
        }
        static string SortLetters(string word)
        {
            string cleaned = word.Replace(" ", "").ToLower();
            return string.Concat(cleaned.OrderBy(c => c));
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

            #region    LINQ - Aggregate Operators

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

            #region     LINQ - Set Operators
            //1.Find the unique Category names from Product List
            //{
            //var res = ProductList.Select(p => p.Category).Distinct();
            //PrintResult(res);
            //}

            //2.Produce a Sequence containing the unique first letter from both product and customer names.
            //{
            //var firstLetterProduct = ProductList.Select(p => p.ProductName[0]).Distinct();
            //PrintResult(firstLetterProduct);
            //Console.WriteLine(new string ('-',30));
            //var firstLetterCustomer = CustomerList.Select(c => c.CustomerName[0]).Distinct();
            //PrintResult(firstLetterCustomer);
            //}

            //3.Create one sequence that contains the common first letter from both product and customer names.
            //{
            //var res = ProductList.Select(p => p.ProductName[0])
            //                     .Intersect(CustomerList.Select(c => c.CustomerName[0]));
            //PrintResult(res);
            //}

            //4.Create one sequence that contains the first letters of product names that are not also first letters
            //of customer names.
            //{
            //var res = ProductList.Select(p => p.ProductName[0])
            //                        .Except(CustomerList.Select(c => c.CustomerName[0]));
            //PrintResult(res);
            //}

            //5.Create one sequence that contains the last Three Characters in each name of all customers
            //and products, including any duplicates
            //{
            //var res = ProductList.Select(p => p.ProductName.Substring(p.ProductName.Length - 3))
            //                        .Concat(CustomerList.Select(c => c.CustomerName.Substring(c.CustomerName.Length - 3)));
            //PrintResult(res);
            //}

            #endregion

            #region LINQ - Quantifiers

            //1.Determine if any of the words in dictionary_english.txt
            //(Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            //{
            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var res = words.Any(p => p.Contains("ei"));
            //Console.WriteLine(res);
            //}

            //2.Return a grouped a list of products only for categories that have at least one product
            //that is out of stock.
            //{
            //var res = from p in ProductList
            //          group p by p.Category 
            //          into g
            //          where g.Any(p => p.UnitsInStock > 0)
            //          select g;
            //foreach (var group in res)
            //{
            //    Console.WriteLine($"Category: {group.Key}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine($"   {product.ProductName} (InStock: {product.UnitsInStock})");
            //    }
            //}
            //}

            //3.Return a grouped a list of products only for categories that have all of their products in stock.
            //{
            //var res = ProductList.GroupBy(p => p.Category)
            //                     .Where(g => g.All(p => p.UnitsInStock > 0));
            //foreach (var group in res)
            //{
            //    Console.WriteLine($"Category: {group.Key}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine($"   {product.ProductName}");
            //}
            //}

            #endregion

            #region    LINQ – Grouping Operators

            //1.Use group by to partition a list of numbers by their remainder when divided by 5
            //{
            //List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            //var res = numbers.GroupBy(p => p % 5);
            //foreach (var group in res)
            //{
            //    Console.WriteLine($"Numbers with a remainder of {group.Key} when divided by 5");
            //    foreach (var word in group)
            //    {
            //        Console.WriteLine(word);
            //    }
            //}

            //2.Uses group by to partition a list of words by their first letter.
            //Use dictionary_english.txt for Input
            //{
            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var res = words.GroupBy(w => w[0]);
            //or
            //var res = from w in words
            //          group w by w[0] into g
            //          select g;
            //foreach (var group in res)
            //{
            //    Console.WriteLine($"Words starting with '{group.Key}':");
            //    foreach (var word in group)
            //    {
            //        Console.WriteLine($"   {word}");
            //    }
            //    Console.WriteLine(new string('-', 30));
            //}
            //}

            //3.Consider this Array as an Input
            //Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            //{
            //string[] Arr = { "from", "salt", "earn", "last", "near", "form" };
            //var res = Arr.GroupBy(w => w, new AnagramEqualityComparer());
            ////or
            ////var res = Arr.GroupBy(word => SortLetters(word));

            //foreach (var group in res)
            //{
            //    foreach (var item in group)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    Console.WriteLine("....");
            //}
            //}
        }

        #endregion

    }
}
