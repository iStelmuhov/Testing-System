﻿using System;

namespace TestingSystem.Model.Session
{
    public class TestResult:Utils.Entity
    {
        public Guid UserId { get; set; }
        public Guid TestSessionId { get; set; }
        public float Score { get; set; }

        protected TestResult(){}

        public TestResult(Guid domainId, Guid userId, Guid testSessionId, float score) : base(domainId)
        {
            UserId = userId;
            TestSessionId = testSessionId;
            Score = score;
        }
    }
}