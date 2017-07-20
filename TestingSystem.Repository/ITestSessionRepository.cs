using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Model.Session;

namespace TestingSystem.Repository
{
    public interface ITestSessionRepository:IRepository<TestSession>
    {
        IQueryable<TestSession> FindUserTestSessions(Guid userId);
    }
}