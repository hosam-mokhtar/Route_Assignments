using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_1_Mcq_Question___Part_2
{
    internal class Rectangle : IRectangle, IShape
    {
        public double Length { get; private set; }
        public double Width { get; set; }
        double IShape.Area => Length * Width;


        public Rectangle(double length, double width)
        {
            if(length <= 0 || width <= 0)
            {
                throw new ArgumentException("Length and Width must be Positive");
            }

            Length = length;
            Width = width;
        }
        void IShape.DisplayShapeInfo()
        {
            Console.WriteLine("Shape: Rectangle");
            Console.WriteLine($"Length: {Length}");
            Console.WriteLine($"Width: {Width}");
            Console.WriteLine($"Area: {((IShape)this).Area:F2}");
        }
    }
}
