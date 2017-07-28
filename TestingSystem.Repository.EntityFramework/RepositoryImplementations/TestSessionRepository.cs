using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestingSystem.Model.Session;

namespace TestingSystem.Repository.EntityFramework.RepositoryImplementations
{
    public class TestSessionRepository:BasicRepository<TestSession>,ITestSessionRepository
    {
        public TestSessionRepository(TestSystemDbContext dbContext)
            : base(dbContext, dbContext.TestSessions)
        {
        }

        public TestSession FindByDomainId(Guid domainId)
        {
            return dbSet.SingleOrDefault(a => a.Id == domainId);
        }

        public IQueryable<Guid> SelectAllDomainIds()
        {
            return dbSet.Select(a => a.Id);
        }

        public IQueryable<TestSession> FindUserTestSessions(Guid userId)
        {
            return dbSet.Where(a => a.UserId == userId);
        }
    }
}