using System;
using System.Collections.Generic;

namespace TestingSystem.Service
{
    public interface IDomainEntityService<T> where T:class
    {
        IList<Guid> ViewAll();

        T View(Guid domainId);
    }
}