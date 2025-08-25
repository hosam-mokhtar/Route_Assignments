using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examination.ConsoleHelper;
namespace Examination
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam Exam { get; set; }

        public Subject(){ }
        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void CreateExam()
        {
            int examType, time, numberOfQuestions;

            string message;

            message = "Please Enter The Type of Exam (1 for Practical | 2 for Final)";
            examType = ReadInt(message, 1, 2);

            message = "Please Enter The Time for from (30 min to 180 min)";
            time = ReadInt(message, 30, 180);

            message = "Please Enter The Number of Questions";
            numberOfQuestions = ReadInt(message, 1, 100);

            if (examType == 1)
                Exam = new PracticalExam(time, numberOfQuestions);
            else
                Exam = new FinalExam(time, numberOfQuestions);

            Console.Clear();
            Exam.CreateListOfQuestions();
        }

    }
}
