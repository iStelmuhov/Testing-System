using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using TestingSystem.Dto;
using TestingSystem.Model.Questions;
using TestingSystem.Model.Session;
using TestingSystem.Repository;

namespace TestingSystem.Service.Impl
{
    public class TestSessionService:ITestSessionService
    {
        [Dependency]
        protected ITestSessionRepository testSessionRepository { get; set; }

        [Dependency]
        protected IQuestionRepository questionRepository { get; set; }

        [Dependency]
        protected ITestResultService testResultService { get; set; }

        public IList<Guid> ViewAll()
        {
            return testSessionRepository.SelectAllDomainIds().ToList();
        }

        public TestSessionDto View(Guid domainId)
        {
            return testSessionRepository.FindByDomainId(domainId).ToDto();
        }

        public void Hide(Guid domainId)
        {
            TestSession ts = RestoreTestSession(domainId);
            ts.Hide();
        }

        public void Unhide(Guid domainId)
        {
            TestSession ts = RestoreTestSession(domainId);
            ts.UnHide();
        }

        public Guid Create(Guid userId, Guid subjectId, int questionsCount)
        {
            IList<Question> questions= questionRepository.FindAllSubjectQuestions(subjectId).ToList();
            if (questions.Count() > questionsCount)
            {
                questions = questions.Randoms(questionsCount).ToList();
            }
            TestInfo testInfo=new TestInfo(Guid.NewGuid(), subjectId,questions);
            TestSession ts=new TestSession(Guid.NewGuid(), userId,testInfo);
            testSessionRepository.Add(ts);

            return ts.Id;
        }

        public void Start(Guid id,DateTime startTime)
        {
            TestSession testSession = RestoreTestSession(id);
            testSession.Start(startTime);
        }

        public TestResultDto End(Guid id,DateTime endTime, Dictionary<int, string[]> answers)
        {
            TestSession testSession = RestoreTestSession(id);
            float score = testSession.End(endTime,answers);

            var res=testResultService.Create(testSession.UserId, testSession.Id, score);
            return testResultService.View(res);
        }

        public IQueryable<TestSession> ViewUserTestSession(Guid userId)
        {
            return testSessionRepository.FindUserTestSessions(userId);
        }

        private TestSession RestoreTestSession(Guid domainId)
        {
            return ServiceUtils.ResolveEntity(testSessionRepository, domainId);
        }

    }
}