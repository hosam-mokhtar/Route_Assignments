using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Threading;
using System;
using Second_Project;
using Third_Project;
using System.Diagnostics.Metrics;
using System.Collections;

namespace First_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region First Project:

            #region 1.Define 3D Point Class and the basic Constructors(use chaining in constructors).

            //Point3D p = new Point3D();

            #endregion

            #region        2.Override the ToString Function to produce this output:
            //Point3D P = new Point3D(10, 10, 10);
            //Console.WriteLine(P.ToString());
            // Output: “Point Coordinates: (10, 10, 10)”.

            //Answer:
            //Point3D P = new Point3D(10, 10, 10);
            //Console.WriteLine(P.ToString());

            #endregion

            #region 3.Read from the User the Coordinates for 2 points P1, P2(Check the input using try Pares, Parse, Convert).

            //Point3D P1 = ReadPointFromUser("P1");
            //Point3D P2 = ReadPointFromUser("P2");

            //Console.WriteLine(P1);
            //Console.WriteLine(P2);

            #endregion

            #region 4.Try to use == If(P1 == P2)   Does it work properly? 

            //Console.WriteLine(P1 == P2);

            #endregion


            #region 5.Define an array of points and sort this array based on X & Y coordinates.

            //Point3D[] points = new Point3D[]
            //{
            //    new Point3D(4, 3, 5),
            //    new Point3D(1, 2, 3),
            //    new Point3D(5,4,0),
            //    new Point3D(2, 8, 1),
            //    new Point3D(-4, 3, 9),
            //    new Point3D(5,2,0)
            //};

            ////Array.Sort(points);

            ////foreach (var point in points)
            ////    Console.WriteLine(point);

            ////Console.WriteLine(new string('-',40));

            //Array.Sort(points, new SortPoint3D());

            //foreach (var point in points)
            //    Console.WriteLine(point);

            #endregion

            #region 6.Implement ICloneable interface to be able to clone the object.
            //To implement more than one interface.
            //class Point3D : IComparable, ICloneable


            //Point3D p1 = new Point3D(10,20,30);
            //Point3D p2 = new Point3D(40,50,60);

            //p1 = (Point3D)p2.Clone();

            //Console.WriteLine(p1);
            //Console.WriteLine(p2);

            #endregion


            #endregion

            #region Second Project:
            #region Define Class Maths that has four methods: Add, Subtract, Multiply, and Divide,
            //each of them takes two parameters.Call each method in Main().
            //Modify the program so that you do not have to create an instance of class to call the four methods.

            //Console.WriteLine(Maths.Add(20, 20));
            //Console.WriteLine(Maths.Subtract(10, 20));
            //Console.WriteLine(Maths.Multiply(20, 20));
            //Console.WriteLine(Maths.Divide(10, 0));

            #endregion
            #endregion


            #region Third Project:
            #region 1.Define Class Duration To include Three Attributes Hours, Minutes and Seconds.

            //Duration d;

            #endregion

            #region 2.Override All System.Object Members(ToString, Equals, GetHasCode).

            //Duration d1 = new Duration();
            //Duration d2 = new Duration();
            //Duration d3 = new Duration(100);

            //Console.WriteLine(d1.GetHashCode());
            //Console.WriteLine(d2.GetHashCode()); // Same d1 code 
            //Console.WriteLine(d3.GetHashCode());

            //Console.WriteLine(d2.Equals(d1)); // true
            //Console.WriteLine(d3.Equals(d1)); // false

            #endregion

            #region 3.Define All Required Constructors to Produce this output:
            /*    Duration D1 = new Duration(1, 10, 15);
                  D1.ToString();
                                Output: Hours: 1, Minutes: 10, Seconds: 15

                  Duration D1 = new Duration(3600);
                  D1.ToString();
                                Output: Hours: 1, Minutes: 0, Seconds: 0

                  Duration D2 = new Duration(7800);
                  D2.ToString();
                                Output: Hours: 2, Minutes: 10, Seconds: 0

                  Duration D3 = new Duration(666);
                  D3.ToString();
                                Output: Minutes: 11, Seconds: 6
            */

            //Duration D1 = new Duration(1, 10, 15);
            //Console.WriteLine(D1.ToString());

            //Duration D2 = new Duration(3600);
            //Console.WriteLine(D2.ToString());

            //Duration D3 = new Duration(7800);
            //Console.WriteLine(D3.ToString());

            //Duration D4 = new Duration(666);
            //Console.WriteLine(D4.ToString());

            #endregion

            #region 4.Implement All required Operators overloading to enable this Code:
            /*
            ●	D3 = D1 + D2
            ●	D3 = D1 + 7800
            ●	D3 = 666 + D3
            ●	D3 = ++D1(Increase One Minute)
            ●	D3 = --D2(Decrease One Minute)
            ●	D1 = D1 - D2
            ●	If(D1 > D2)
            ●	If(D1 <= D2)
            ●	If(D1)
            ●	DateTime Obj = (DateTime)D1
            */

            //Duration dd = D1 + D2;
            //Console.WriteLine(dd.ToString());
            //dd = D3 + 7800;
            //Console.WriteLine(dd.ToString());
            //dd = 666 + D3;
            //Console.WriteLine(dd.ToString());
            //dd++;
            //Console.WriteLine(dd.ToString());
            //dd--;
            //Console.WriteLine(dd.ToString());
            //D1 = D1 - D2;
            //Console.WriteLine(D1.ToString());

            //Console.WriteLine($"D1 > D2 : {D1 > D2}");
            //Console.WriteLine($"D1 <= D2 : {D1 <= D2}");
            //Console.WriteLine($"D1 : {D1}");

            //DateTime obj = (DateTime)D1;
            //Console.WriteLine($"DateTime : {obj}");

            #endregion
            #endregion

        }
        public static Point3D ReadPointFromUser(string s)
        {
            int px, py, pz;

            Console.WriteLine($"Enter point[{s}] [X]:");
            px = ReadInt($"Enter point[{s}] [X]:");

            Console.WriteLine($"Enter point[{s}] [Y]:");
            py = ReadInt($"Enter point[{s}] [Y]:");

            Console.WriteLine($"Enter point[{s}] [Z]:");
            pz = ReadInt($"Enter point[{s}] [Z]:");

            return new Point3D(px, py, pz);
        }
        public static int ReadInt(string s)
        {
            int v;

            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out v))
                    break;
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.WriteLine(s);
            }

            return v;
        }
    }
}
