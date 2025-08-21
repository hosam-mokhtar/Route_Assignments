using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    internal class SortPoint3D : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x is not Point3D P1) return 1;
            if (y is not Point3D P2) return -1;

            int cmp = P1.X.CompareTo(P2.X);
            if (cmp != 0)
                return cmp;

            return P1.Y.CompareTo(P2.Y);
        }
    }
}
