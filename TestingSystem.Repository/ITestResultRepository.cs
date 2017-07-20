using System;
using System.Linq;
using TestingSystem.Model.Session;

namespace TestingSystem.Repository
{
    public interface ITestResultRepository:IRepository<TestResult>
    {
        IQueryable<TestResult> FindAllUserTestResults(Guid userId);
        IQueryable<TestResult> FindAllSubjectTestResults(Guid subjectId);
        IQueryable<TestResult> FindAllCategoryTestResults(Guid categoryId);
    }
}