using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.Classes
{
    internal class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book() : this("0", "", new string[] { "Unknown" }, DateTime.MinValue, 0)
        {
        }
        public Book(string iSBN) : this(iSBN, "", new string[] { "Unknown" }, DateTime.MinValue, 0)
        {
        }
        public Book(string iSBN, string title) : this(iSBN, title, new string[] { "Unknown" }, DateTime.MinValue, 0)
        {
        }
        public Book(string iSBN, string title, string[] authors) : this(iSBN, title, authors, DateTime.Now, 0)
        {
        }
        public Book(string iSBN, string title, string[] authors, DateTime publicationDate) : this(iSBN, title, authors, publicationDate, 0)
        {
        }
        public Book(string iSBN, string title, string[] authors, DateTime publicationDate, decimal price)
        {
            ISBN = iSBN;
            Title = title;
            Authors = authors;
            PublicationDate = publicationDate;
            Price = price;
        }
        public override string ToString()
        {
            string authorsList = string.Join(", ", Authors);

            return $"ISBN: {ISBN} , Title: {Title} , Author: {authorsList} , " +
                   $"Publication Date: {PublicationDate:dd/mmm/yyyy} , Price : {Price}";
        }
    }
}
