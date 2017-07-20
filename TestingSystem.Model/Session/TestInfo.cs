using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Model.Questions;

namespace TestingSystem.Model.Session
{
    public class TestInfo
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public IList<Question> Questions { get; set; }
        public int QuestionsCount => Questions.Count;

        public int CountScore(IDictionary<int,string[]> answers)
        {
            if (answers==null)
                throw new ArgumentNullException($"Answers can't be null!");
            return answers.Count(answer => Questions[answer.Key].CheckAnswer(answer.Value));
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(SubjectId)}: {SubjectId}, {nameof(Questions)}: {Questions}, {nameof(QuestionsCount)}: {QuestionsCount}";
        }
    }
}