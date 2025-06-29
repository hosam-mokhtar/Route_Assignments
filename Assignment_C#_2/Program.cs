namespace Assignment_C__2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1 - write a program that allows the user to enter a number then print it.

            Console.WriteLine("enter a number");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine($"number: {x}");
            #endregion

            #region 2 - write c# program that converts a string to an integer, but the string contains non-numeric characters. and mention what will happen 

            string s = "hossam";
            //     Console.WriteLine(int.Parse(s));        // error because must digit , i can solve this error by try_parse and loop if i need to enter digit value 
            //      Console.WriteLine(Convert.ToInt32(s)); // error because must digit , i can solve this error by try_parse and loop if i need to enter digit value 

            Console.WriteLine(int.TryParse(s, out int value)); // false
            #endregion


            #region  3 - Write C# program that Perform a simple arithmetic operation with floating-point numbers And mention what will happen

            float n1 = 5.5f;
            var n2 = 4.1f;
            Console.WriteLine(n1 + n2);

            #endregion

            #region  4 - Write C# program that Extract a substring from a given string.

            string word = "Hello World";
            Console.WriteLine(word.Substring(0, 5));  // 0: start index & 5: length  result: hello

            #endregion

            #region  5 - Write C# program that Assigning one value type variable to another and modifying the value of one variable and mention what will happen

            int num1 = 10;
            int num2 = num1;

            num1 = 50;

            Console.WriteLine(num1); //50
            Console.WriteLine(num2); //10

            #endregion

            #region   6 - Write C# program that Assigning one reference type variable to another and modifying the object through one variable and mention what will happen

            // this program has more solutions
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = arr1;

            arr1[0] = 100;

            Console.WriteLine(arr2[0]);  //100

            #endregion

            #region          7 - Write C# program that take two string variables and print them as one variable 

            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();

            Console.WriteLine(firstWord + secondWord);

            #endregion

            #region  8 - Which of the following statements is correct about the C#.NET code snippet given below?

            int d;
            d = Convert.ToInt32(!(30 < 20));

            Console.WriteLine(d);                    // A value 1 will be assigned to d.
            #endregion


            #region           9 - Which of the following is the correct output for the C# code given below?

            Console.WriteLine(13 / 2 + " " + 13 % 2);      // 6 1


            #endregion

            #region           10 - What will be the output of the C# code given below?

            int num = 1, z = 5;

            if (!(num <= 0))
                Console.WriteLine(++num + z++ + " " + ++z);   // 7 7      
            else
                Console.WriteLine(--num + z-- + " " + --z);

            #endregion

        }
    }
}
