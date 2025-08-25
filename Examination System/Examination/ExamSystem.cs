using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examination.ConsoleHelper;

namespace Examination
{
    internal static class ExamSystem
    {
        public static void Start()
        {
            Subject subject = new Subject(1, "OOP");

            subject.CreateExam();
            Console.Clear();

            string message = "Do you want to Start Exam (Y|N)";
            char choice = ReadChar(message, 'Y', 'y', 'N', 'n');

            if (choice is 'Y' or 'y')
            {
                Console.Clear();

                Stopwatch sw = new Stopwatch();
                sw.Start();

                subject.Exam.ShowExam();

                sw.Stop();

                Console.WriteLine($"Time = {sw.Elapsed}");
            }

            Console.WriteLine("Thank you");
        }
    }
}
