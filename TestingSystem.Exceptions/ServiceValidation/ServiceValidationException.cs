using System;

namespace TestingSystem.Exceptions.ServiceValidation
{
    public class ServiceValidationException : Exception
    {
        public ServiceValidationException(string message)
            : base(message)
        { }
    }
}