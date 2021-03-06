﻿using System;
using System.Collections.Generic;

namespace TestingSystem.Dto
{
    public class TestResultDto:DomainEntityDto<TestResultDto>
    {
        public Guid UserId { get; private set; }
        public Guid TestSessionId { get; private set; }
        public float Score { get; private set; }

        public TestResultDto(Guid domainId, bool show, Guid userId, Guid testSessionId, float score)
            : base(domainId, show)
        {
            UserId = userId;
            TestSessionId = testSessionId;
            Score = score;
        }


        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { UserId, TestSessionId, Score };
        }
    }
}