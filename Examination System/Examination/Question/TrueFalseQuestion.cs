using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examination.ConsoleHelper;

namespace Examination
{
    internal class TrueFalseQuestion : Question
    {
        public override string Header => $"True | False Question";

        public TrueFalseQuestion()
        {
            Answers = new Answer[2];
            Answers[0] = new Answer(1, "True");
            Answers[1] = new Answer(2, "False");
        }
        public override void AddQuestion()
        {
            Console.WriteLine(Header);
            string message;

            message = "Please Enter Question Body";
            Body = ReadString(message);

            message = "Please Enter Question Mark";
            Mark = ReadInt(message, min: 1);


            message = "Please Enter the right answer id (1 for true | 2 for false)";
            RightAnswer.Id = ReadInt(message, min: 1, max: 2);
            RightAnswer.Text = Answers[RightAnswer.Id - 1].Text;

            Console.Clear();
        }
    }
}
