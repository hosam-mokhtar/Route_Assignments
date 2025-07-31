using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Part_1_Mcq_Question___Part_2
{
    internal interface IShape
    {
        public double Area { get; }

        void DisplayShapeInfo();

    }
}
