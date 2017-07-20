using System;
using System.Linq;

namespace TestingSystem.Repository
{
    public interface IRepository<T>
    {
        void StartTransaction();

        void Commit();

        void Rollback();

        int Count();

        T Load(int id);

        IQueryable<T> LoadAll();

        void Add(T t);

        void Delete(T t);

        T FindByDomainId(Guid domainId);

        IQueryable<Guid> SelectAllDomainIds();
    }
}