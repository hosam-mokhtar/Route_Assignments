using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examination.ConsoleHelper;

namespace Examination
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void CreateListOfQuestions()
        {
            Questions = new Question[NumberOfQuestions];

            for (var i = 0; i < Questions?.Length; i++)
            {
                string message = "Please Enter the Type of Question (1 for MCQ | 2 For True | False)";
                int choice = ReadInt(message, min: 1, max: 2);

                Console.Clear();

                if (choice == 1)
                {
                    Questions[i] = new MCQQuestion();
                    Questions[i].AddQuestion();
                }
                else
                {
                    Questions[i] = new TrueFalseQuestion();
                    Questions[i].AddQuestion();
                }
            }
        }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine(question);

                for (int i = 0; i < question?.Answers?.Length; i++)
                    Console.WriteLine(question.Answers[i]);

                string message;

                if (question?.GetType() == typeof(MCQQuestion))
                {
                    message = "Please Enter The answer Id ";
                    question.UserAnswer.Id = ReadInt(message, min: 1, max: 3);
                }
                else
                {
                    message = "Please Enter The answer Id (1 For True | 2 For False) ";
                    question.UserAnswer.Id = ReadInt(message, min: 1, max: 2);
                }

                question.UserAnswer.Text = question.Answers[question.UserAnswer.Id - 1].Text;
            }

            Console.Clear();

            ResultExam();
        }

        public override void ResultExam()
        {
            int grade = 0, totalMarks = 0;

            for (int i = 0; i < Questions?.Length; i++)
            {
                totalMarks += Questions[i].Mark;

                if (Questions[i].UserAnswer.Id == Questions[i].RightAnswer.Id)
                    grade += Questions[i].Mark;

                Console.WriteLine($"Question {i + 1} : {Questions[i].Body}");
                Console.WriteLine($"Your Answer => {Questions[i].UserAnswer.Text}");
                Console.WriteLine($"Your Answer => {Questions[i].RightAnswer.Text}");
            }

            Console.WriteLine($"Your Grade is {grade} from {totalMarks}");
        }
    }
}
