using System;
using System.Data.Entity;
using System.Linq;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository.EntityFramework.RepositoryImplementations
{
    public class SubjectRepository:BasicRepository<Subject>,ISubjectRepository
    {
        public SubjectRepository(TestSystemDbContext dbContext) 
            : base(dbContext, dbContext.Subjects)
        {
        }

        public Subject FindByDomainId(Guid domainId)
        {
            return dbSet.SingleOrDefault(a => a.Id == domainId);
        }

        public IQueryable<Guid> SelectAllDomainIds()
        {
            return dbSet.Select(a => a.Id);
        }

        public Subject FindByName(string name)
        {
            return dbSet.SingleOrDefault(a => a.Name == name);
        }
    }
}