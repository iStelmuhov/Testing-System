using System.Collections.Generic;
using TestingSystem.Repository;
using TestingSystem.Repository.EntityFramework;

namespace TestingSystem.TestApp
{
    class ModelSaver
    {
        public ModelSaver(TestSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Save(TestSystemModel m)
        {

            SaveCollection(RepositoryFactory.MakeAccountRepository(dbContext), m.Accouts);
            SaveCollection(RepositoryFactory.MakeCategoryRepository(dbContext), m.Categories);
            SaveCollection(RepositoryFactory.MakeSubjectRepository(dbContext), m.Subjects);
            SaveCollection(RepositoryFactory.MakeQuestionRepository(dbContext), m.Questions);           
            SaveCollection(RepositoryFactory.MakeTestResultRepository(dbContext), m.TestResults);
            SaveCollection(RepositoryFactory.MakeTestSessionRepository(dbContext), m.TestSessions);

        }

        private TestSystemDbContext dbContext;


        private void SaveCollection<TRepository, TEntity>(TRepository repository, ICollection<TEntity> collection)
            where TRepository : IRepository<TEntity>
            where TEntity : class 
        {
            foreach (TEntity obj in collection)
                repository.Add(obj);

            repository.Commit();
        }
    }
}