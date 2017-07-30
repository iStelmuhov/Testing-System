using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository.EntityFramework.RepositoryImplementations
{
    public class QuestionRepository:BasicRepository<Question>,IQuestionRepository
    {
        public QuestionRepository(TestSystemDbContext dbContext) 
            : base(dbContext, dbContext.Questions)
        {
        }

        public Question FindByDomainId(Guid domainId)
        {
            return dbSet.SingleOrDefault(a => a.Id == domainId);
        }

        public IQueryable<Guid> SelectAllDomainIds()
        {
            return dbSet.Select(a => a.Id);
        }

        public IQueryable<Question> FindAllSubjectQuestions(Guid subjectId)
        {
            return dbSet.Where(a => a.Subject.Id == subjectId);
        }

    }
}