namespace Stack___Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region  1.implement a function to reverse the elements of a queue using a stack.
            //Given a Queue.

            ////Answer:
            //Queue<int> ints = new Queue<int>();
            //ints.Enqueue(1);
            //ints.Enqueue(2);
            //ints.Enqueue(3);
            //ints.Enqueue(4);

            //Queue<int> result = ReverseQueue(ints);

            //while (result.Count > 0)
            //{
            //    Console.WriteLine(result.Peek());
            //    result.Dequeue();
            //}

            #endregion

            #region  2.Given a Stack, implement a function to check 
            //if a string of parentheses is balanced using a stack.
            // Ex:
            //Input:
            //    [()]{}
            //Output:
            //    Balanced

            ////Answer:
            //string s = "[()]{}";
            //Console.WriteLine($"String of Parentheses is {IsBalanced(s)}");

            #endregion
        }

        static Queue<T> ReverseQueue<T>(Queue<T> values)
        {
            Stack<T> stack = new Stack<T>();

            while (values.Count > 0)
            {
                stack.Push(values.Dequeue());
            }

            while (stack.Count > 0)
            {
                values.Enqueue(stack.Pop());
            }

            return values;
        }
        static string IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                    stack.Push(s[i]);
                else if (stack.Count > 0 &&
                       (s[i] == ')' && stack.Peek() == '('
                       || s[i] == ']' && stack.Peek() == '['
                       || s[i] == '}' && stack.Peek() == '{'))
                    stack.Pop();
                else if (s[i] == ' ')
                    continue;
                else
                    return "Not Balanced";
            }

            return stack.Count == 0 ? "Balanced" : "Not Balanced";
        }
    }
}
