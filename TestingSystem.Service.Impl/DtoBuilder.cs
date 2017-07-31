using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;
using TestingSystem.Dto;
using TestingSystem.Model.Accounts;
using TestingSystem.Model.Questions;
using TestingSystem.Model.Session;

namespace TestingSystem.Service.Impl
{
    public static class DtoBuilder
    {
        public static AccountDto ToDto(this Account account)
        {
            return new AccountDto(account.Id,account.Show,account.FirstName,account.LastName,account.UserRole,account.Email,account.Image);
        }

        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto(category.Id,category.Show,category.Name,category.Description,category.Image);
        }

        public static QuestionDto ToDto(this Question question)
        {
            return new QuestionDto(question.Id,question.Show,question.QuestionText, question.GetPossibleAnswers().ToList(),question.GetQuestionType(),question.Subject.ToDto());
        }

        public static SubjectDto ToDto(this Subject subject)
        {
            return new SubjectDto(subject.Id,subject.Show,subject.Name,subject.Description,subject.Category.ToDto(),subject.MaxDuration,subject.Image);
        }

        public static TestInfoDto ToDto(this TestInfo testInfo)
        {
            return new TestInfoDto(testInfo.Id,testInfo.Show,testInfo.SubjectId,testInfo.Questions.Select(a=>a.ToDto()).ToList(),testInfo.QuestionsCount);
        }

        public static TestSessionDto ToDto(this TestSession testSession)
        {
            return new TestSessionDto(testSession.Id,testSession.Show,testSession.StartTime,testSession.EndTime,testSession.Duration,testSession.UserId,testSession.TestInfo.ToDto(),testSession.IsEnded,testSession.IsActive);
        }

        public static TestResultDto ToDto(this TestResult testResult)
        {
            return new TestResultDto(testResult.Id,testResult.Show,testResult.UserId,testResult.TestSessionId,testResult.Score);
        }

        public static Subject ToEntity(this SubjectDto subjectDto)
        {
            return new Subject(subjectDto.DomainId,subjectDto.Name,subjectDto.Description,subjectDto.Category.ToEntity(),subjectDto.MaxDuration,subjectDto.Image);
        }

        public static Category ToEntity(this CategoryDto categoryDto)
        {
            return new Category(categoryDto.DomainId, categoryDto.Name, categoryDto.Description, categoryDto.Image);
        }

        public static TextOption ToEntity(this TextOptionDto textOption)
        {
            return new TextOption(textOption.DomainId,textOption.Text,textOption.IsCorrect);
        }
    }
}