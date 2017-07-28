using System;
using Microsoft.Win32;
using TestingSystem.Model.Session;

namespace TestingSystem.Service
{
    public interface ITestSessionService:IDomainEntityService<ITestSessionService>
    {
        Guid Create(Guid userId, Guid subjectId);
        void Start(Guid id);
        TestResult End(Guid id);
        TestSession ViewUserTestSession(Guid userId);
    }
}