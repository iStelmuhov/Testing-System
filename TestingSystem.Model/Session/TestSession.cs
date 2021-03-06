﻿using System;
using System.Collections.Generic;
using TestingSystem.Exceptions.DomainLogic;
using TestingSystem.Model.Accounts;

namespace TestingSystem.Model.Session
{
    public class TestSession:Utils.Entity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan SessionDuration { get; set; }
        public virtual Guid UserId { get; set; }
        public TestInfo TestInfo { get; set; }
        public bool IsEnded { get; private set; }
        public bool IsActive { get; private set; }

        protected TestSession(){}

        public TestSession(Guid domainId, Guid userId, TestInfo testInfo) : base(domainId)
        {
            UserId = userId;
            TestInfo = testInfo;
            StartTime=DateTime.Now;
            EndTime=DateTime.Now;
            SessionDuration=TimeSpan.Zero;
        }


        public void Start(DateTime startTime)
        {
            if (IsEnded == true)
                throw new InvalidOperationException("Test ssesion are ended!");
            if(IsActive == true)
                throw new InvalidOperationException("Test ssesion are already started!");

            StartTime = startTime;
            IsActive = true;
        }

        public float End(DateTime endTime, Dictionary<int, string[]> answers)
        {
            if (IsEnded == true)
                throw new InvalidOperationException("Test ssesion are already ended!");
            if (IsActive == false)
                throw new InvalidOperationException("Test ssesion are not started!");

            IsActive = false;
            IsEnded = true;
            EndTime = endTime;

            return TestInfo.CountScore(answers);

        }
        
    }
}