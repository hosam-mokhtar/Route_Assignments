using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class FixedSizeList<T>
    {
        private List<T> list;
        private int counter;
        public int Capacity { get; }

        public FixedSizeList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("Capacity must be greater than zero");

            Capacity = capacity;
            list = new List<T>();
            counter = 0;
        }
        public void Add(T value)
        {
            if (counter >= Capacity)
                throw new IndexOutOfRangeException();

            list.Add(value);
            counter++;
        }
        public T Get(int index)
        {
            if (index < Capacity && index >= 0)
                return list[index];
            else
                throw new IndexOutOfRangeException();
        }

    }
}
