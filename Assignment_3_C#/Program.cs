using System.Reflection.Metadata;

namespace Assignment_3_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region    1- Write a program that takes a number from the user then print yes if that number can be divided by 3 and 4 otherwise print no.

            int x = int.Parse(Console.ReadLine());

            if (x % 3 == 0 && x % 4 == 0)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            #endregion

            #region   2- Write a program that allows the user to insert an integer then print negative if it is negative number otherwise print positive.

            int num = int.Parse(Console.ReadLine());

            if (num < 0)
                Console.WriteLine("Negative");
            else
                Console.WriteLine("Positive");

            #endregion

            #region 3- Write a program that takes 3 integers from the user then prints the max element and the min element.


            Console.WriteLine("Enter Number 1:");
            int n1 = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Enter Number 2:");
            int n2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number 3:");
            int n3 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Max Element :{Math.Max(Math.Max(n1,n2),n3)}");
            Console.WriteLine($"Max Element :{Math.Min(Math.Min(n1, n2), n3)}");

            #endregion

            #region  4- Write a program that allows the user to insert an integer number then check If a number is even or odd.

            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
                Console.WriteLine("Even");
            else
                Console.WriteLine("Odd");

            #endregion

            #region  5- Write a program that takes character from the user then if it is a vowel chars (a,e,I,o,u) then print (vowel) otherwise print (consonant).
           
            const string vowels= "aeiouAEIOU";
            char ch =Char.Parse(Console.ReadLine());

            if (vowels.Contains(ch))
                Console.WriteLine("vowel");
            else
                Console.WriteLine("consonant");


            // Other Solution
            /*
             
            const string vowels= "aeiouAEIOU";
            char ch = Char.Parse(Console.ReadLine());

            if (vowels.IndexOf(ch) > -1)
                Console.WriteLine("vowel");
            else
                Console.WriteLine("consonant");
            */

            #endregion
        }
    }
}
