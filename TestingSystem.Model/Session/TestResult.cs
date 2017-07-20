using System;

namespace TestingSystem.Model.Session
{
    public class TestResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TestSessionId { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(UserId)}: {UserId}, {nameof(TestSession)}: {TestSessionId}, {nameof(Score)}: {Score}";
        }
    }
}