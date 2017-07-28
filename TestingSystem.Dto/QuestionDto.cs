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
        public CategoryDto Category { get; private set; }

        public QuestionDto(Guid domainId, string question, IList<string> answers, QuestionType type, CategoryDto category) : base(domainId)
        {
            Question = question;
            Answers = answers;
            Type = type;
            Category = category;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[]{Question,Category,Answers};
        }

        public override string ToString()
        {
            return $"{nameof(Question)}: {Question}, {nameof(Answers)}: {Answers}, {nameof(Type)}: {Type}, {nameof(Category)}: {Category}";
        }
    }
}