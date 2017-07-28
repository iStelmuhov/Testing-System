using System;
using System.Linq;
using TestingSystem.Model.Session;

namespace TestingSystem.Service
{
    public interface ITestResultService:IDomainEntityService<TestResult>
    {
        Guid Create(Guid userId,Guid sessionId,int score);
        void ChangeUserId(Guid id, Guid newUserId);
        void ChangeTestSessionId(Guid id, Guid newTestSessionId);
        void ChangeScore(Guid id, int newScore);
        IQueryable<TestResult> ViewAllUserTestResults(Guid userId);
        IQueryable<TestResult> ViewAllSubjectTestResults(Guid subjectId);
        IQueryable<TestResult> FindAllCategoryTestResults(Guid categoryId);
    }
}