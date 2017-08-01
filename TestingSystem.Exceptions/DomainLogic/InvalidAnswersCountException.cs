using System;

namespace TestingSystem.Exceptions.DomainLogic
{
    public class InvalidAnswersCountException:DomainLogicException
    {
        public InvalidAnswersCountException(Guid testSessionId) 
            : base($"Count of answers not equal count of questions in test session:{testSessionId}")
        {
        }
    }
}