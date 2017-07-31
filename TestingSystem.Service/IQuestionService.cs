using System;
using System.Collections.Generic;
using TestingSystem.Dto;

namespace TestingSystem.Service
{
    public interface IQuestionService:IDomainEntityService<QuestionDto>
    {
        Guid CreateSimpleQuewstion(Guid subjectId, string text, ISet<TextOptionDto> answers);
        Guid CreateWriteQuestion(Guid subjectId, string text, IList<string> possibleAnswers);

        void EditQuestion(Guid questionId, EditQuestionDto editedQuestion);
    }
}