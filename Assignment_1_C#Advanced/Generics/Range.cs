using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
  internal class Range<T> : IComparable<Range<T>> where T : IComparable<T>
	{
        public T Minimum { get; set; }
        public T Maximum { get; set; }

        public Range(T minimum, T maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
        public bool IsInRange(T value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            return value.CompareTo(Minimum) >= 0 && value.CompareTo(Maximum) <= 0;
        }
        public dynamic Length()
        {
            try
            {
                return (dynamic)Maximum - (dynamic)Minimum;
            }
            catch
            {
                throw new InvalidOperationException($"Cannot calculate Difference for type {typeof(T).Name}.");
            }
        }
        public int CompareTo(Range<T>? other)
        {
            if (other == null)
                return 1;

            int minComparison = this.Minimum.CompareTo(other.Minimum);

            if (minComparison != 0)
                return minComparison;

            return this.Maximum.CompareTo(other.Maximum);
        }
    }
}
