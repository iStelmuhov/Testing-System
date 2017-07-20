using System.Collections.Generic;
using TestingSystem.Repository;
using TestingSystem.Repository.EntityFramework;

namespace TestingSystem.TestApp
{
    class ModelRestorer
    {
        public ModelRestorer(TestSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TestSystemModel Restore()
        {
            TestSystemModel m = new TestSystemModel();

            RestoreCollection(RepositoryFactory.MakeAccountRepository(dbContext), m.Accouts);
            RestoreCollection(RepositoryFactory.MakeCategoryRepository(dbContext), m.Categories);
            RestoreCollection(RepositoryFactory.MakeQuestionRepository(dbContext), m.Questions);
            RestoreCollection(RepositoryFactory.MakeSubjectRepository(dbContext), m.Subjects);
            RestoreCollection(RepositoryFactory.MakeTestResultRepository(dbContext), m.TestResults);
            RestoreCollection(RepositoryFactory.MakeTestSessionRepository(dbContext), m.TestSessions);

            return m;
        }

        private TestSystemDbContext dbContext;


        private void RestoreCollection<TEntity>(IRepository<TEntity> repository, ICollection<TEntity> target)
            where TEntity : class 
        {
            foreach (TEntity obj in repository.LoadAll())
                target.Add(obj);
        }
    }
}