using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using Delegate.Classes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Delegate.Classes.BookFunctions;

namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01:
            // 1.Considering the Code Below, Write Down the Body of all Listed Methods and Properties and Constructor:
            //Answered
            #endregion

            #region Part 02:
            // 1.You need to parameterize ProcessBooks function to accept BookFunctions Methods using following cases: 
            // a)	Create User Defined Delegate with the same signature of methods existed in Bookfunctions class.
            
            List<Book> books = new List<Book>()
                 {
                     new Book("1", "SQL", new string[] {"Hossam", "Radwa"}, new DateTime(2000, 1, 1), 2000),
                     new Book("2", "C#", new string[] {"Nada"}, new DateTime(2001, 2, 2), 1500),
                     new Book("3", "OOP", new string[] {"Route"}, new DateTime(2002, 3, 3), 1500),
                     new Book("4", "Clean Code", new string[] {"Uncle Bob"}, new DateTime(2003, 4, 4),1000)
                 };

            //LibraryEngine.ProcessBooks(books, new BookFunctionDelegate(GetTitle));
            //Console.WriteLine(new string('-', 50));

            // b)	Use the Proper build in delegate. 

            LibraryEngine.ProcessBooks(books, new Func<Book, string>(BookFunctions.GetAuthors));
            Console.WriteLine(new string('-', 50));

            // c)   Anonymous Method(GetISBN).

            LibraryEngine.ProcessBooks(books, delegate (Book b) { return b.ISBN; });
            Console.WriteLine(new string('-',50));

            LibraryEngine.ProcessBooks(books, delegate (Book b) { return b.Title; });
            Console.WriteLine(new string('-', 50));

            // d)	Lambda Expression(GetPublicationDate).

            LibraryEngine.ProcessBooks(books, b => b.PublicationDate.ToShortDateString());
            Console.WriteLine(new string('-', 50));

            LibraryEngine.ProcessBooks(books, b => b.Price.ToString());

            #endregion
        }

    }
}
