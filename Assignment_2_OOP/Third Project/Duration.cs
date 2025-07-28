using System;

namespace Third_Project
{
    public class Duration
    {
        private int _hours;
        private int _minutes;
        private int _seconds;
        public int Hours
        {
            get => _hours;
            set
            {
                if (value <= 24)
                    _hours = value;
                else
                    _hours = 0;
            }
        }
        public int Minutes
        {
            get => _minutes;
            set
            {
                if (value <= 59)
                    _minutes = value;
                else
                    _minutes = 0;
            }
        }
        public int Seconds
        {
            get => _seconds;
            set
            {
                if (value <= 59)
                    _seconds = value;
                else
                    _seconds = 0;
            }
        }
        public Duration()
        {
        }
        public Duration(int seconds)
        {
            CalculateTime(seconds);
        }
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public void CalculateTime(int seconds)
        {
            Hours = seconds / 3600;
            seconds %= 3600;
            Minutes = seconds / 60;
            seconds %= 60;
            Seconds = seconds;
        }

        public override string ToString()
        {
            string total = "";

            if (Hours > 0)
                total += $"Hours: {Hours}, ";
            if (Hours > 0 || Minutes > 0)
                total += $"Minutes: {Minutes}, ";

            total += $"Seconds: {Seconds}";
            return total;

        }
        public int TotalSeconds()
        {
            return (Hours * 3600) + (Minutes * 60) + Seconds;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        public override bool Equals(object obj)
        {
            if (obj is Duration other)
            {
                return this.Hours == other.Hours &&
                       this.Minutes == other.Minutes && 
                       this.Seconds == other.Seconds;
            }
            return false;
        }

        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.TotalSeconds() + d2.TotalSeconds());
        }

        public static Duration operator +(Duration d, int seconds)
        {
            return new Duration(d.TotalSeconds() + seconds);
        }

        public static Duration operator +(int seconds, Duration d)
        {
            return new Duration(seconds + d.TotalSeconds());
        }

        public static Duration operator ++(Duration d)
        {
            return new Duration(d.TotalSeconds() + 60);
        }
        public static Duration operator --(Duration d)
        {
            return new Duration(d.TotalSeconds() - 60);
        }
        public static Duration operator -(Duration d1, Duration d2)
        {
            return new Duration(d1.TotalSeconds() - d2.TotalSeconds());
        }
        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.TotalSeconds() > d2.TotalSeconds();
        }
        public static bool operator <(Duration d1, Duration d2)
        {
            return d1.TotalSeconds() < d2.TotalSeconds();
        }
        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.TotalSeconds() <= d2.TotalSeconds();
        }
        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.TotalSeconds() >= d2.TotalSeconds();
        }
        public static bool operator true(Duration d)
        {
            return d.TotalSeconds() > 0;
        }
        public static bool operator false(Duration d)
        {
            return d.TotalSeconds() <= 0;
        }
        public static explicit operator DateTime(Duration d)
        {
            return new DateTime(2025,7,28,hour:d.Hours,minute:d.Minutes,second:d.Seconds);
        }

    }
}
