using System;

namespace TestingSystem.Exceptions.DomainLogic
{
    public class DuplicateNamedEntityException : DomainLogicException
    {
        public DuplicateNamedEntityException(Type t, string name)
            : base(string.Format("Duplicate {0} object called \"{1}\"", t.Name, name))
        { }
    }
}