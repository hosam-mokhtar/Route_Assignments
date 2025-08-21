using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Delegate.Classes.BookFunctions;

namespace Delegate.Classes
{
    internal class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, /*BookFunctionDelegate*/ Func<Book, string> fptr)
        {
            if (bList is not null && fptr is not null)
            {
                foreach (Book B in bList)
                {
                    Console.WriteLine(fptr(B));
                }
            }
        }
    }

}
