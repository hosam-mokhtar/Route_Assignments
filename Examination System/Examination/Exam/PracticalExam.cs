using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examination.ConsoleHelper;

namespace Examination
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void CreateListOfQuestions()
        {
            Questions = new MCQQuestion[NumberOfQuestions];

            for (int i = 0; i < Questions?.Length; i++)
            {
                Questions[i] = new MCQQuestion();
                Questions[i].AddQuestion();
            }

            Console.Clear();
        }

        public override void ShowExam()
        {

            foreach (var question in Questions)
            {
                Console.WriteLine(question);

                for (int i = 0; i < question?.Answers?.Length; i++)
                    Console.WriteLine(question.Answers[i]);

                Console.WriteLine(new string('-',40));

                string message = "Please Enter The answer Id";
                question.UserAnswer.Id = ReadInt(message, min: 1, max: 3);
                question.UserAnswer.Text = question.Answers[question.UserAnswer.Id - 1].Text;

            }

            Console.Clear();

            Console.WriteLine("Right Answers");

            for (int i = 0; i < Questions?.Length; i++)
            {
                Console.WriteLine($"Question Number {i + 1} : {Questions[i].Body}");
                Console.WriteLine($"Your Answer => {Questions[i].UserAnswer.Text}");
                Console.WriteLine($"Right Answer => {Questions[i].RightAnswer.Text}");

                Console.WriteLine("-------------------------------------------------------");
            }
        }
    }
}
