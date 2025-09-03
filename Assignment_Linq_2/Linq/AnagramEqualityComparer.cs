using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;

            string cleanX = x.Replace(" ", "").ToLower();
            string cleanY = y.Replace(" ", "").ToLower();

            if (cleanX.Length != cleanY.Length) return false;

            return string.Concat(cleanX.OrderBy(c => c)) == string.Concat(cleanY.OrderBy(c => c));
        }

        public int GetHashCode(string obj)
        {
            if (obj == null) return 0;

            string cleaned = obj.Replace(" ", "").ToLower();
            string sorted = string.Concat(cleaned.OrderBy(c => c));
            return sorted.GetHashCode();
        }
    }
}
