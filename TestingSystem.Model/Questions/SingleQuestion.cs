using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TestingSystem.Model.Questions
{
    public class SingleQuestion:Question
    {
        public IList<TextOption> WrongAnswers { get; set; }
        public TextOption CorrectAnswer { get; set; }

        protected SingleQuestion()
        {
            Type=QuestionType.SingleAnswer;
        }

        public SingleQuestion(Guid domainId, Subject subject, string questionText, IList<TextOption> wrongAnswers, TextOption correctAnswer) 
            : base(domainId, subject, questionText)
        {
            Type=QuestionType.SingleAnswer;
            WrongAnswers = wrongAnswers;
            CorrectAnswer = correctAnswer;
        }

        public override IList<TextOption> GetPossibleAnswers()
        {
            var answers = WrongAnswers;
            answers.Add(CorrectAnswer);
            return answers;
        }

        public override bool CheckAnswer(params string[] answers)
        {
            return answers == null || answers.Length != 1
                ? throw new ArgumentException("Invalid answers count!")
                : answers.Contains(CorrectAnswer.Text);
        }
    }
}