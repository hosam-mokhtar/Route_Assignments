using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examination.ConsoleHelper;

namespace Examination
{
    internal class MCQQuestion : Question
    {
        public override string Header => "MCQ Question";

        public MCQQuestion()
        {
            Answers = new Answer[3];
        }
        public override void AddQuestion()
        {
            Console.WriteLine(Header);

            string message;

            message = "Please Enter Question Body";
            Body = ReadString(message);

            message = "Please Enter Question Mark";
            Mark = ReadInt(message, min: 1);
       
            Console.WriteLine("Choices Of Question");

            for (int i = 0; i < Answers.Length; i++)
            {
                Answers[i] = new Answer() { Id = i + 1 };

                message = $"Please Enter Choice number {i + 1}";
                Answers[i].Text = ReadString(message);
            }

            message = "Please Enter the right answer id";
            RightAnswer.Id = ReadInt (message, min: 1, max: 3);

            RightAnswer.Text = Answers[RightAnswer.Id - 1].Text;

            Console.Clear();
        }
    }
}
