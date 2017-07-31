using System;
using System.Collections;
using System.Collections.Generic;
using TestingSystem.Model.Questions;

namespace TestingSystem.Dto
{
    public class QuestionDto:DomainEntityDto<QuestionDto>
    {
        public string Question;
        public IList<string> Answers { get; private set; }
        public QuestionType Type { get; private set; }
        public SubjectDto Subject { get; private set; }

        public QuestionDto(Guid domainId, bool show, string question, IList<string> answers, QuestionType type, SubjectDto subject)
            : base(domainId, show)
        {
            Question = question;
            Answers = answers;
            Type = type;
            Subject = subject;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[]{Question, Subject, Answers};
        }

        public override string ToString()
        {
            return $"{nameof(Question)}: {Question}, {nameof(Answers)}: {Answers}, {nameof(Type)}: {Type}, {nameof(SubjectDto)}: {Subject}";
        }
    }
}