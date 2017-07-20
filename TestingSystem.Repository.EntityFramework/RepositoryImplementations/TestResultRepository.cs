using System;
using System.Data.Entity;
using System.Linq;
using TestingSystem.Model.Session;

namespace TestingSystem.Repository.EntityFramework.RepositoryImplementations
{
    public class TestResultRepository:BasicRepository<TestResult>,ITestResultRepository
    {
        public TestResultRepository(TestSystemDbContext dbContext) 
            : base(dbContext, dbContext.TestResults)
        {
        }

        public TestResult FindByDomainId(Guid domainId)
        {
            return dbSet.SingleOrDefault(a => a.Id == domainId);
        }

        public IQueryable<Guid> SelectAllDomainIds()
        {
            return dbSet.Select(a => a.Id);
        }

        public IQueryable<TestResult> FindAllUserTestResults(Guid userId)
        {
            return dbSet.Where(a => a.UserId == userId);
        }

        public IQueryable<TestResult> FindAllSubjectTestResults(Guid subjectId)
        {

            return dbSet.Where(a => GetDBContext()
                                        .TestSessions.SingleOrDefault(b => b.Id == a.TestSessionId)
                                        .TestInfo.SubjectId == subjectId);
        }

        public IQueryable<TestResult> FindAllCategoryTestResults(Guid categoryId)
        {
            var subjects = GetDBContext().Subjects.Where(a => a.Category.Id == categoryId).Select(a=>a.Id).ToList();
            return dbSet.Where(a => subjects.Contains(GetDBContext()
                .TestSessions.SingleOrDefault(b => b.Id == a.TestSessionId)
                .TestInfo.SubjectId));
        }
    }
}