using System;
using System.Linq;
using TestingSystem.Dto;
using TestingSystem.Model.Session;

namespace TestingSystem.Service
{
    public interface ITestResultService:IDomainEntityService<TestResultDto>
    {
        Guid Create(Guid userId,Guid sessionId, float score);
        void ChangeUserId(Guid id, Guid newUserId);
        void ChangeTestSessionId(Guid id, Guid newTestSessionId);
        void ChangeScore(Guid id, int newScore);
        IQueryable<TestResultDto> ViewAllUserTestResults(Guid userId);
        IQueryable<TestResultDto> ViewAllSubjectTestResults(Guid subjectId);
        IQueryable<TestResultDto> FindAllCategoryTestResults(Guid categoryId);
    }
}