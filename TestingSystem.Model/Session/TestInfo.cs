using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Model.Questions;

namespace TestingSystem.Model.Session
{
    public class TestInfo:Utils.Entity
    {
        public Guid SubjectId { get; set; }
        public IList<Question> Questions { get; set; }
        public int QuestionsCount => Questions.Count;

        protected TestInfo(){}

        public TestInfo(Guid domainId, Guid subjectId, IList<Question> questions) : base(domainId)
        {
            SubjectId = subjectId;
            Questions = questions;
        }

        public int CountScore(IDictionary<int,string[]> answers)
        {
            if (answers==null)
                throw new ArgumentNullException($"Answers can't be null!");
            return answers.Count(answer => Questions[answer.Key].CheckAnswer(answer.Value));
        }

    }
}