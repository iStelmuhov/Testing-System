using System;
using System.Collections.Generic;
using TestingSystem.Model.Session;

namespace TestingSystem.Dto
{
    public class TestSessionDto:DomainEntityDto<TestSessionDto>
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public TimeSpan Duration { get; private set; }
        public Guid UserId { get; private set; }
        public TestInfoDto TestInfo { get; private set; }
        public bool IsEnded { get; private set; }
        public bool IsActive { get; private set; }

        public TestSessionDto(Guid domainId, DateTime startTime, DateTime endTime, TimeSpan duration, Guid userId, TestInfoDto testInfo, bool isEnded, bool isActive) : base(domainId)
        {
            StartTime = startTime;
            EndTime = endTime;
            Duration = duration;
            UserId = userId;
            TestInfo = testInfo;
            IsEnded = isEnded;
            IsActive = isActive;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[]{UserId,StartTime,TestInfo};
        }

        public override string ToString()
        {
            return $"{nameof(StartTime)}: {StartTime}, {nameof(EndTime)}: {EndTime}, {nameof(Duration)}: {Duration}, {nameof(UserId)}: {UserId}, {nameof(TestInfo)}: {TestInfo}, {nameof(IsEnded)}: {IsEnded}, {nameof(IsActive)}: {IsActive}";
        }
    }
}