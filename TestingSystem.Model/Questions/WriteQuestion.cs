using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingSystem.Model.Questions
{
    public class WriteQuestion :Question
    {
        public ISet<TextOption> PossibleAnswers { get; set; }

        protected WriteQuestion()
        {}

        public WriteQuestion(Guid domainId, Subject subject, string questionText, ISet<TextOption> possibleAnswers) 
            : base(domainId, subject, questionText)
        {
            PossibleAnswers = possibleAnswers;
        }

        public override IList<string> GetPossibleAnswers()
        {
            return PossibleAnswers.Select(a=>a.Text).ToList();
        }

        public override bool CheckAnswer(params string[] answers)
        {
            var correctAnswers = PossibleAnswers.Select(a=>a.Text).ToList();
            correctAnswers.ForEach(a => a = a.ToUpper());

            return answers == null || answers.Length != 1
                ? throw new ArgumentException("Invalid answers count!")
                : correctAnswers.Contains(answers[0].ToUpper());
        }

        public override void AddAnswer(TextOption answer)
        {
            PossibleAnswers.Add(answer);
        }

        public override void RemoveAnswer(Guid answerId)
        {
            PossibleAnswers.Remove(PossibleAnswers.SingleOrDefault(a => a.Id == answerId));
        }

        public override void EditAnswer(TextOption answer)
        {
            RemoveAnswer(answer.Id);
            AddAnswer(answer);
        }

        public override QuestionType GetQuestionType()
        {
            return QuestionType.WriteAnswer;
        }

        public override void ClearAnswers()
        {
            PossibleAnswers.Clear();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(PossibleAnswers)}: {PossibleAnswers}";
        }
    }
}