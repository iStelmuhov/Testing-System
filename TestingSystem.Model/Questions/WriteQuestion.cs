using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingSystem.Model.Questions
{
    public class WriteQuestion :Question
    {
        public IList<TextOption> PossibleAnswers { get; set; }

        protected WriteQuestion()
        {
            Type = QuestionType.WriteAnswer;
        }

        public WriteQuestion(Guid domainId, Subject subject, string questionText, IList<TextOption> possibleAnswers) : base(domainId, subject, questionText)
        {
            Type=QuestionType.WriteAnswer;
            PossibleAnswers = possibleAnswers;
        }

        public override IList<TextOption> GetPossibleAnswers()
        {
            return new List<TextOption>();
        }

        public override bool CheckAnswer(params string[] answers)
        {
            var correctAnswers = PossibleAnswers.Select(a=>a.Text).ToList();
            correctAnswers.ForEach(a => a = a.ToUpper());

            return answers == null || answers.Length != 1
                ? throw new ArgumentException("Invalid answers count!")
                : correctAnswers.Contains(answers[0].ToUpper());
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(PossibleAnswers)}: {PossibleAnswers}";
        }
    }
}