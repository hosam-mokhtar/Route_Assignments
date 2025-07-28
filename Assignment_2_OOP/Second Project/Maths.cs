using System.ComponentModel;

namespace Second_Project
{
    static public class Maths
    {
        public static int Add(int number1, int number2)
        {
            return number1 + number2;
        }
        public static int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }
        public static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }
        public static double Divide(int number1, int number2)
        {
            if (number2 == 0)
                throw new DivideByZeroException();
            return number1 / number2 * 1.0;
        }

    }
}
