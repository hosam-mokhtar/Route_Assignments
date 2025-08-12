using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using System.Xml.Linq;
using System.Drawing;
using System.Numerics;
using System.Threading.Channels;

namespace Collections
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region 1.You are given an ArrayList containing a sequence of elements. 
            //try to reverse the order of elements in the ArrayList in-place(in the same arrayList)
            //without using the built-in Reverse.Implement a function
            //that takes the ArrayList as input and modifies it to have the reversed order of elements.

            //Answer:
            //ArrayList arrayList = new ArrayList();
            //arrayList.AddRange(new int[] { 1, 2, 3, 4 });
            //arrayList.Add("Hossam");
            //arrayList.Add(50000);
            //ArrayList array = ReverseArrayList(arrayList);
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 2.You are given a list of integers. 
            //Your task is to find and return a new list containing only the even numbers
            //from the given list.

            //Answer:
            //List<int> list = new List<int>();
            //list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //List<int> result= GetEvenNumbers(list);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region  3.implement a custom list called FixedSizeList<T> with a predetermined capacity.
            //This list should not allow more elements than its capacity and should provide clear messages
            //if one tries to exceed it or access invalid indices.

            // Requirements:
            //1.Create a generic class named FixedSizeList<T>.
            //2.Implement a constructor that takes the fixed capacity of the list as a parameter.
            //3.Implement an Add method that adds an element to the list,
            //but throws an exception if the list is already full.
            //4.Implement a Get method that retrieves an element at a specific index
            //in the list but throws an exception for invalid indices.


            ////Answer:
            //FixedSizeList<int> list = new FixedSizeList<int>(4);
            //list.Add(10);
            //list.Add(20);
            //list.Add(30);
            //list.Add(40);
            //list.Add(50);                      //Exception
            //Console.WriteLine(list.Get(0));
            //Console.WriteLine(list.Get(3));
            //Console.WriteLine(list.Get(6));    //Exception


            #endregion

            #region  4.Given an array  consists of  numbers with size N and number of queries, 
            //in each query you will be given an integer X, and you should print
            //how many numbers in array that is greater than  X.
            //Ex:
            //Input
            //3 3                //Size of array , number of queries
            //11 5 3             //Array 
            //1                  //Query1
            //5                  //Query2
            //13                 //Query 3
            //Output
            //3                  //11,5,3
            //1                  //11
            //0

            ////Answer:
            //int[] arr = new int[GetSizeOfArray()];
            //GetElementsFromUser(arr);

            //Console.WriteLine("-------------------------Enter Queries-----------------------");

            //int[] queries = new int[GetSizeOfArray()];
            //GetElementsFromUser(queries);

            //int[] result = CheckEquality(arr, queries);

            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.WriteLine($"Query [{i + 1}]: {result[i]}");
            //}

            #endregion

            #region  5.Given a number N and an array of N numbers.Determine if it's palindrome or not.
            //Ex:
            //Input:
            //5
            //1 3 2 3 1
            //Output:
            //YES

            ////Answer:
            //Console.WriteLine($"Palindrome is: {CheckPalindrome(GetSizeOfArray())}");

            #endregion

            #region  6.Given an array, implement a function to remove duplicate elements from an array.

            ////Answer:
            //// First Solution using HashSet
            //HashSet<int> nums = RemoveDuplicateElements([ 10, 20, 10, 40, 50, 10, 20, 50, 60 ]);

            //foreach(var item in nums)
            //{
            //    Console.WriteLine(item);
            //}

            //// Other Solution using Sort and List

            //string[] names = { "Hos", "Radwa", "nada", "nada", "Hos" };

            //string[] nums2 = RemoveDuplicateElements2(names);

            //foreach (var item in nums2)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region  7.Given an array list, implement a function to remove all odd numbers from it.

            //ArrayList arrayList = new ArrayList();
            //arrayList.AddRange(new int[]{1,2,3,4,5,6});
            //arrayList.Add("Hossam");
            //arrayList.Add(5.5);
            //arrayList.Add(null);

            //ArrayList array = RemoveOddNumbers(arrayList);

            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion
        }
        static public List<int> GetEvenNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 != 0)
                    list.RemoveAt(i);
            }

            return list;
        }
        static public ArrayList ReverseArrayList(ArrayList arrayList)
        {
            ArrayList temp = new ArrayList();

            for (int i = arrayList.Count - 1; i >= 0; i--)
            {
                temp.Add(arrayList[i]);
            }
            return temp;
        }
        static public HashSet<T> RemoveDuplicateElements<T>(T[] array)
        {
            HashSet<T> set = new HashSet<T>();

            for (int i = 0; i < array.Length; i++)
            {
                set.Add(array[i]);
            }
            return set;
        }
        static public T[] RemoveDuplicateElements2<T>(T[] array)
        {
            Array.Sort(array);
            List<T> list = new List<T>(array);

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].Equals(list[i + 1]))
                    list.RemoveAt(i);
            }

            return list.ToArray();
        }
        static public ArrayList RemoveOddNumbers(ArrayList arrayList)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                try
                {
                    if ((int?)arrayList[i] % 2 != 0)
                        arrayList.RemoveAt(i);
                }
                catch
                {
                    continue;
                }
            }
            return arrayList;
        }
        static public int[] CheckEquality(int[] arr, int[] queries)
        {
            int[] result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] > queries[i])
                        result[i]++;
                }
            }

            return result;
        }
        static public int[] GetElementsFromUser(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                bool isNumber;
                int value;
                do
                {
                    Console.WriteLine($"Enter Element[{i + 1}]:");
                    isNumber = int.TryParse(Console.ReadLine(), out value);
                }
                while (!isNumber);

                arr[i] = value;
            }
            return arr;
        }
        static public int GetSizeOfArray()
        {
            int size = 0;
            bool isNumber;
            do
            {
                Console.WriteLine("Enter Size of Array:");
                isNumber = int.TryParse(Console.ReadLine(), out size);
            }
            while (!isNumber);

            return size;
        }
        static public bool CheckPalindrome(int size)
        {
            int[] array = new int[size];

            GetElementsFromUser(array);

            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[array.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
