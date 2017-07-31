using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Exceptions.DomainLogic;

namespace TestingSystem.Model.Questions
{
    public class SimpleQuestion : Question
    {
        public ISet<TextOption> Answers { get; set; }

        protected SimpleQuestion()
        {
        }

        public SimpleQuestion(Guid domainId, Subject subject, string questionText, ISet<TextOption> answers) : base(domainId, subject, questionText)
        {
            Answers = answers;
        }

        public override IList<string> GetPossibleAnswers()
        {
            return Answers.Select(a => a.Text).ToList();
        }

        public override bool CheckAnswer(params string[] answers)
        {
            return answers.All(answer => Answers.SingleOrDefault(a => a.Text == answer).IsCorrect);
        }

        public override void AddAnswer(TextOption answer)
        {
            Answers.Add(answer);
        }

        public override void RemoveAnswer(Guid answerId)
        {
            Answers.Remove(Answers.SingleOrDefault(a => a.Id == answerId));
        }

        public override void EditAnswer(TextOption answer)
        {
            RemoveAnswer(answer.Id);
            AddAnswer(answer);
        }

        public override QuestionType GetQuestionType()
        {
            int correctAnswerCount = Answers.Count(a => a.IsCorrect);
            return correctAnswerCount == 0
                ? throw new NoCorrectAnswersException(QuestionText)
                : (correctAnswerCount > 1 ? QuestionType.MultiAnswer : QuestionType.SingleAnswer);
        }

        public override void ClearAnswers()
        {
            Answers.Clear();
        }
    }
}