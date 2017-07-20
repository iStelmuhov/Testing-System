using System;
using System.Data.Entity;
using System.Linq;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository.EntityFramework.RepositoryImplementations
{
    public class CategoryRepository:BasicRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(TestSystemDbContext dbContext) 
            : base(dbContext, dbContext.Categories)
        {
        }

        public Category FindByDomainId(Guid domainId)
        {
            return dbSet.SingleOrDefault(a => a.Id == domainId);
        }

        public IQueryable<Guid> SelectAllDomainIds()
        {
            return dbSet.Select(a => a.Id);
        }
    }
}