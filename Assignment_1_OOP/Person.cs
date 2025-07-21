using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_OOP
{
    internal struct Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public override string ToString()
        {
            return $"Name: {name}, Age: {age}";
        }

    }
}
