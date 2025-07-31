using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Part_1_Mcq_Question___Part_2
{
    internal class Circle: ICircle
    {
        public double Radius { get; private set; }

        double IShape.Area => Math.PI * Radius * Radius;

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be Positive");
            }

            Radius = radius;
        }

        void IShape.DisplayShapeInfo()
        {
            Console.WriteLine("Shape: Circle");
            Console.WriteLine($"Radius: {Radius}");
            Console.WriteLine($"Area: {((IShape)this).Area:F2}");
        }
    }
}
