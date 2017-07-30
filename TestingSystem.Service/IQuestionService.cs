using System;
using System.Collections.Generic;
using TestingSystem.Dto;

namespace TestingSystem.Service
{
    public interface IQuestionService:IDomainEntityService<QuestionDto>
    {
        Guid CreateSingleQuestion(Guid subjectId, string text, IList<string> wrongAnswers, string correctAnswer);
        Guid CreateMultiQuestion(Guid subjectId, string text, IList<string> wrongAnswers, IList<string> correctAnswers);
        Guid CreateWriteQuestion(Guid subjectId, string text, IList<string> possibleAnswers);

        void ChangeQuestionText(Guid questionId, string newText);
        void ChangeCorrectAnswer(Guid questionId, string correctAnswer);
    }
}