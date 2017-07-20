using System;
using TestingSystem.Model.Accounts;

namespace TestingSystem.Model.Session
{
    public class TestSession
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public virtual Account User { get; set; }
        public virtual TestInfo TestInfo { get; set; }
        public bool IsEnded { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(StartTime)}: {StartTime}, {nameof(EndTime)}: {EndTime}, {nameof(Duration)}: {Duration}, {nameof(User)}: {User}, {nameof(TestInfo)}: {TestInfo}, {nameof(IsEnded)}: {IsEnded}";
        }
    }
}