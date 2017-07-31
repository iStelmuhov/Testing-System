using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using TestingSystem.Dto;
using TestingSystem.Model.Questions;
using TestingSystem.Repository;

namespace TestingSystem.Service.Impl
{
    public class QuestionService:IQuestionService
    {
        [Dependency]
        protected IQuestionRepository questionRepository { get; set; }

        [Dependency]
        protected ISubjectRepository subjectRepository { get; set; }

        public IList<Guid> ViewAll()
        {
            return questionRepository.SelectAllDomainIds().ToList();
        }

        public QuestionDto View(Guid domainId)
        {
            return questionRepository.FindByDomainId(domainId).ToDto();
        }

        public void Hide(Guid domainId)
        {
            Question question = ResolveQuestion(domainId);
            question.Hide();
        }

        public void Unhide(Guid domainId)
        {
            Question question = ResolveQuestion(domainId);
            question.UnHide();
        }

        public Guid CreateSimpleQuewstion(Guid subjectId, string text, ISet<TextOptionDto> answers)
        {
            SimpleQuestion question=new SimpleQuestion(Guid.NewGuid(),ResolveSubject(subjectId),text,new HashSet<TextOption>(answers.Select(a=>a.ToEntity())));
            questionRepository.Add(question);
            return question.Id;
        }

        public Guid CreateWriteQuestion(Guid subjectId, string text, IList<string> possibleAnswers)
        {
            throw new NotImplementedException();
        }

        public void EditQuestion(Guid questionId, EditQuestionDto editedQuestion)
        {
            Question q = ResolveQuestion(questionId);
            q.ClearAnswers();
            q.Subject = editedQuestion.Subject.ToEntity();
            foreach (var answer in editedQuestion.Answers)
            {
                q.AddAnswer(answer.ToEntity());
            }
        }

        private Question ResolveQuestion(Guid id)
        {
            return ServiceUtils.ResolveEntity(questionRepository, id);
        }

        private Subject ResolveSubject(Guid subjectId)
        {
            return ServiceUtils.ResolveEntity(subjectRepository, subjectId);
        }
    }
}