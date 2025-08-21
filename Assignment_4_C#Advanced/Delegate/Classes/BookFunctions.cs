using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.Classes
{
    internal class BookFunctions
    {
        public delegate string BookFunctionDelegate(Book book);
        public static string GetISBN(Book b) => b.ISBN;
        public static string GetTitle(Book b) => b.Title;
        public static string GetAuthors(Book b) => string.Join(", ", b.Authors);
        public static string GetPublicationDate(Book b) => b.PublicationDate.ToShortDateString();
        public static string GetPrice(Book b) => $"Price: {b.Price}";


    }
}
