using System;
using TestingSystem.Exceptions.ServiceValidation;
using TestingSystem.Repository;

namespace TestingSystem.Service.Impl
{
    sealed class ServiceUtils
    {
        private ServiceUtils() { }

        public static TEntity ResolveEntity<TEntity>(
            IRepository<TEntity> repository,
            Guid domainId
        ) where TEntity : class 
        {
            TEntity entity = repository.FindByDomainId(domainId);
            if (entity != null)
                return entity;

            throw new ServiceUnresolvedEntityException(typeof(TEntity), domainId);
        }
    }
}