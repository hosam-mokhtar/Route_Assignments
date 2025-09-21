using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x is null && y is null) return true; 
            if (x is null || y is null) return false;
            
            return SortLetters(x) == SortLetters(y);
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return SortLetters(obj).GetHashCode();
        }
        static public string SortLetters(string word)
        {
            var res = word.ToLower().ToCharArray();
            Array.Sort(res);

            return new string(res);

            //or
            //return new string(word.Trim().ToLower().ToCharArray().OrderBy(c => c).ToArray());
        }

        //public string SortLetters(string word)
        //{
        //    string cleaned = word.Replace(" ", "").ToLower();

        //    return new string(cleaned.OrderBy(c => c).ToArray());
        //}
    }
}
