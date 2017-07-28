using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using TestingSystem.Model.Questions;

namespace TestingSystem.Dto
{
    public class TestInfoDto:DomainEntityDto<TestInfoDto>
    {
        public Guid SubjectId { get; set; }
        public IList<QuestionDto> Questions { get; set; }
        public int QuestionsCount { get; set; }

        public TestInfoDto(Guid domainId, Guid subjectId, IList<QuestionDto> questions, int questionsCount) : base(domainId)
        {
            SubjectId = subjectId;
            Questions = questions;
            QuestionsCount = questionsCount;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[]{SubjectId,Questions};
        }

        public override string ToString()
        {
            return $"{nameof(SubjectId)}: {SubjectId}, {nameof(Questions)}: {Questions}, {nameof(QuestionsCount)}: {QuestionsCount}";
        }
    }
}