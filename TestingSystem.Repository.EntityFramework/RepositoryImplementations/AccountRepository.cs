using System;
using System.Data.Entity;
using System.Linq;
using TestingSystem.Model.Accounts;

namespace TestingSystem.Repository.EntityFramework.RepositoryImplementations
{
    public class AccountRepository:BasicRepository<Account>,IAccountRepository
    {
        public AccountRepository(TestSystemDbContext dbContext)
            : base(dbContext, dbContext.Accounts) {}

        public Account FindByDomainId(Guid domainId)
        {
            return dbSet.SingleOrDefault(e => e.Id == domainId);
        }

        public IQueryable<Account> FindByName(string firstName, string lastName)
        {
            return dbSet.Where(e => e.FirstName == firstName && e.LastName == lastName);
        }

        public Account FindByEmail(string email)
        {
            return dbSet.SingleOrDefault(e => e.Email == email);
        }

        public IQueryable<Guid> SelectAllDomainIds()
        {
            return dbSet.Select(e => e.Id);
        }
    }
}