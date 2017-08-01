using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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

        public override float CheckAnswer(params string[] answers)
        {
            float score = 0;
            int correctAnswersCount = Answers.Count(a => a.IsCorrect);
            if(correctAnswersCount==0)
                throw new NoCorrectAnswersException(QuestionText);

            float k = (float) 1 / correctAnswersCount;

            foreach (var answer in answers)
            {
                var option = Answers.SingleOrDefault(a => a.Text == answer);
                if (option != null && option.IsCorrect)
                    score += k;
            }

            return score;


            //return answers.All(answer => Answers.SingleOrDefault(a => a.Text == answer).IsCorrect);
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