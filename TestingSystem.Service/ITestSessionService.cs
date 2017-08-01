using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using TestingSystem.Dto;
using TestingSystem.Model.Session;

namespace TestingSystem.Service
{
    public interface ITestSessionService:IDomainEntityService<TestSessionDto>
    {
        Guid Create(Guid userId, Guid subjectId,int questionsCount);
        void Start(Guid id,DateTime startTime);
        TestResultDto End(Guid id, DateTime endTime,Dictionary<int,string[]> answers);
        IQueryable<TestSession> ViewUserTestSession(Guid userId);
    }
}