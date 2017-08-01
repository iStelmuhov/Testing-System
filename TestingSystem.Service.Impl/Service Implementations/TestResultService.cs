using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Microsoft.Practices.Unity;
using TestingSystem.Dto;
using TestingSystem.Model.Session;
using TestingSystem.Repository;

namespace TestingSystem.Service.Impl
{
    public class TestResultService:ITestResultService
    {
        [Dependency]
        protected ITestResultRepository testResultRepository { get; set; }

        public IList<Guid> ViewAll()
        {
            return testResultRepository.SelectAllDomainIds().ToList();
        }

        public TestResultDto View(Guid domainId)
        {
            return ResolveTestResult(domainId).ToDto();
        }

        public void Hide(Guid domainId)
        {
            TestResult tr = ResolveTestResult(domainId);
            tr.Hide();
        }

        public void Unhide(Guid domainId)
        {
            TestResult tr = ResolveTestResult(domainId);
            tr.UnHide();
        }

        public Guid Create(Guid userId, Guid sessionId, float score)
        {
            TestResult tr=new TestResult(Guid.NewGuid(), userId,sessionId,score);
            testResultRepository.Add(tr);
            return tr.Id;
        }

        public void ChangeUserId(Guid id, Guid newUserId)
        {
            TestResult tr = ResolveTestResult(id);
            tr.UserId = newUserId;
        }

        public void ChangeTestSessionId(Guid id, Guid newTestSessionId)
        {
            TestResult tr = ResolveTestResult(id);
            tr.TestSessionId = newTestSessionId;
        }

        public void ChangeScore(Guid id, int newScore)
        {
            TestResult tr = ResolveTestResult(id);
            tr.Score = newScore;
        }

        public IQueryable<TestResultDto> ViewAllUserTestResults(Guid userId)
        {
            return testResultRepository.FindAllUserTestResults(userId).Select(a=>a.ToDto());
        }

        public IQueryable<TestResultDto> ViewAllSubjectTestResults(Guid subjectId)
        {
            return testResultRepository.FindAllSubjectTestResults(subjectId).Select(a => a.ToDto());
        }

        public IQueryable<TestResultDto> FindAllCategoryTestResults(Guid categoryId)
        {
            return testResultRepository.FindAllCategoryTestResults(categoryId).Select(a => a.ToDto());
        }

        private TestResult ResolveTestResult(Guid domainId)
        {
            return ServiceUtils.ResolveEntity(testResultRepository, domainId);
        }
    }
}