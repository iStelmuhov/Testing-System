using System;
using Microsoft.Win32;
using TestingSystem.Dto;
using TestingSystem.Model.Session;

namespace TestingSystem.Service
{
    public interface ITestSessionService:IDomainEntityService<TestSessionDto>
    {
        Guid Create(Guid userId, Guid subjectId);
        void Start(Guid id);
        TestResultDto End(Guid id);
        TestSession ViewUserTestSession(Guid userId);
    }
}