using System;

namespace TestingSystem.Exceptions.DomainLogic
{
    public class DomainLogicException : Exception
    {
        public DomainLogicException(string message)
            : base(message)
        { }
    }
}