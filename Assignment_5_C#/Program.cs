using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Assignment_5_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region       19 - Write a program that prints an identity matrix using for loop, 
            //in other words takes a value n from the user and shows the identity table of size n * n.

            Console.WriteLine("Enter Size of Array: ");
            int size = int.Parse(Console.ReadLine());

            int[,] arr = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                        arr[i, j] = 1;
                    else
                        arr[i, j] = 0;
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
            #endregion

            #region       20 - Write a program in C# Sharp to find the sum of all elements of the array

            int sum = 0;
            int[,] array = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
            }

            Console.WriteLine($"Sum: {sum}");

            #endregion

            #region        21 - Write a program in C# Sharp to merge two arrays of the same size sorted in ascending order.

            Console.WriteLine("Enter Size of Array: ");
            int size = int.Parse(Console.ReadLine());

            int[] arr1 = new int[size];
            int[] arr2 = new int[size];

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine($"arr1 Enter Element [{i + 1}]: ");
                arr1[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                Console.WriteLine($"arr2 Enter Element [{i + 1}]: ");
                arr2[i] = int.Parse(Console.ReadLine());
            }

            int[] mergedarray = new int[size * 2];
            int index = 0;

            for (int i = 0; i < arr1.Length; i++)
            {

                mergedarray[index] = arr1[i];
                index++;
                mergedarray[index] = arr2[i];
                index++;
            }

            Array.Sort(mergedarray);

            for (int i = 0; i < mergedarray.Length; i++)
            {
                Console.Write(mergedarray[i] + " ");
            }
            #endregion

            #region      22 - Write a program in C# Sharp to count the frequency of each element of an array.

            Dictionary<int, int> dict = [];
            int[] arr = { 1, 2, 3, 0, 2, 4, 9, 10, 6, 4, 8, 7, 0, 2, 3, 3, 4, 49, 9, 7 };

            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                    dict.Add(arr[i], 1);
                else
                    dict[arr[i]]++;
            }

            foreach (var i in dict.Keys)
            {
                Console.WriteLine($"Element: [{i}] has frequency: {dict[i]}");
            }

            #endregion

            #region    23 - Write a program in C# Sharp to find maximum and minimum element in an array.

            int max = int.MinValue;
            int min = int.MaxValue;
            int[] arr = [10, 50, 100, 120, 14, 40, 48, 6, 3, 0, -7, 60];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }

            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");

            #endregion

            #region    24 - Write a program in C# Sharp to find the second largest element in an array.

            int firstMax = int.MinValue;
            int secondMax = int.MinValue;

            int[] arr = [10, 50, 100, 120, 14, 109, 40, 48, 6, 3, 0, -7, 60];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > firstMax)
                {
                    secondMax = firstMax;
                    firstMax = arr[i];
                }
                else if (arr[i] > secondMax)
                {
                    secondMax = arr[i];
                }
            }

            Console.WriteLine($"Second Max: {secondMax}");

            #endregion

            #region     25 -Consider an Array of Integer values with size N, having values as in this Example.

            // 7   0   0   0   5   6   7   5   0   7   5   3

            //write a program find the longest distance between Two equal cells.In this example.
            // The distance is measured by the number Of cells- for example, the distance between the first and the fourth cell is 2(cell 2 and cell 3).

            //In the example above, the longest distance is between the first 7 and the
            //10th 7, with a distance of 8 cells, i.e.the number of cells between the 1st
            //And the 10th 7s.

            //Note:
            //-Array values will be taken from the user
            //-If you have input like 1111111 then the distance is the number of
            //Cells between the first and the last cell.


            Console.WriteLine("Enter Size of Array: ");
            int size = int.Parse(Console.ReadLine());

            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter Element [{i + 1}]: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            int maxDistance = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                        maxDistance = Math.Max(maxDistance, j - i - 1);
                }
            }

            Console.WriteLine($"Max Distance: {maxDistance}");

            #endregion

            #region     26 - Given a list of space separated words, reverse the order of the words.

            string[] words = new string[3];
            words[0] = "         this is a test ";
            words[1] = "   all    your base ";
            words[2] = "  Word  ";

            for (int i = 0; i < words.Length; i++)
            {
                List<string> wordInSentence = new List<string>();
                string s = words[i].Trim();
                string singleWord = "";

                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] != ' ')
                        singleWord += s[j];
                    else if (s[j] == ' ' && singleWord.Length > 0)
                    {
                        wordInSentence.Add(singleWord);
                        singleWord = "";
                    }
                }

                wordInSentence.Add(singleWord);
                words[i] = "";

                for (int j = wordInSentence.Count - 1; j >= 0; j--)
                {
                    words[i] += wordInSentence[j];
                    if (j != 0)
                        words[i] += ' ';
                }
            }

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"Output [{i + 1}]: {words[i]}");
            }

            #endregion

            #region 27 - Write a program to create two multidimensional arrays of same size. 
            //Accept value from user and store them in first array. Now copy all the elements of first array on second array and print second array.

            Console.WriteLine("Enter number of Rows: ");
            int sizeRows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of Columns: ");
            int sizeColumns = int.Parse(Console.ReadLine());

            int[,] firstArray = new int[sizeRows, sizeColumns];
            int[,] secondArray = new int[sizeRows, sizeColumns];

            for (int i = 0; i < sizeRows; i++)
            {
                for (int j = 0; j < sizeColumns; j++)
                {
                    Console.WriteLine($"First Array Enter Element: [{i + 1}] [{j + 1}]");
                    firstArray[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < sizeRows; i++)
            {
                for (int j = 0; j < sizeColumns; j++)
                {
                    secondArray[i, j] = firstArray[i, j];
                }
            }
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Second Array Elements: ");

            for (int i = 0; i < sizeRows; i++)
            {
                for (int j = 0; j < sizeColumns; j++)
                {
                    Console.Write($"{secondArray[i, j]} ");
                }
            }

            #endregion

            #region       28 - Write a Program to Print One Dimensional Array in Reverse Order.

            int[] arr = { 1, 2, 3, 4, 5, 6 };

            Console.Write("Reverse Order: ");
            for (int i = arr.Length - 1; i >= 0; i--)
            {

                Console.Write(arr[i] + " ");
            }

            #endregion

        }
    }
}
