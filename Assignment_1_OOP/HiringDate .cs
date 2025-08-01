using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_OOP
{
    internal class HiringDate
    {
        private int _day;
        private int _month;
        private int _year;
        public int Day
        {
            get { return _day; }
            set { _day = value >= 1 && value <= 31 ? value : 1; }
        }
        public int Month
        {
            get { return _month; }
            set { _month = value >= 1 && value <= 12 ? value : 1; }
        }
        public int Year
        {
            get { return _year; }
            set { _year = value >= 2000 && value <= 2025 ? value: 2000; }
        }

        public HiringDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString() {

            return $"{Day:00}/{Month:00}/{Year}";
        }
    }
}
