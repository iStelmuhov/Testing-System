using System;
using System.Collections.Generic;
using TestingSystem.Model.Questions;

namespace TestingSystem.Dto
{
    public class EditQuestionDto:DomainEntityDto<EditQuestionDto>
    {
        public string QuestionText;
        public SubjectDto Subject { get; private set; }
        public ISet<TextOptionDto> Answers { get; private set; }

        public EditQuestionDto(Guid domainId, bool show, string questionText, SubjectDto subject, ISet<TextOptionDto> answers) 
            : base(domainId, show)
        {
            QuestionText = questionText;
            Subject = subject;
            Answers = answers;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[]{ QuestionText, Subject};
        }
    }
}