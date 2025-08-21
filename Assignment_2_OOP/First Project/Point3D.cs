using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    internal class Point3D : IComparable<Point3D>,ICloneable
    {
        private int _x { get; set; }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y { get; set; }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        private int _z { get; set; }
        public int Z
        {
            get { return _z; }
            set { _z = value; }
        }
        public Point3D() : this(0, 0, 0) { }
        public Point3D(int x) : this(x, 0, 0) { }
        public Point3D(int x, int y) : this(x, y, 0) { }
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z}).";
        }
        public override bool Equals(object obj)
        {
            if (obj is Point3D other)
            {
                return X == other.X &&
                       Y == other.Y &&
                       Z == other.Z;
            }
            return false;
        }

        public static bool operator ==(Point3D p1, Point3D p2)
        {
            return Equals(p1, p2);
        }
        public static bool operator !=(Point3D p1, Point3D p2)
        {
            return Equals(p1, p2);
        }

        public object Clone()
        {
            return new Point3D(X,Y,Z);
            /*
            return new Point3D()
            {
                X = this.X,
                Y = this.Y,
                Z = this.Z,
            };
            */
        }

        public int CompareTo(Point3D? obj)
        {
            if (obj is not Point3D other)
                return 1;

            return this.X.CompareTo(other.X);
        }
    }
}
