using TestingSystem.Repository.EntityFramework.RepositoryImplementations;

namespace TestingSystem.Repository.EntityFramework
{
    public static class RepositoryFactory
    {
        public static IAccountRepository MakeAccountRepository(TestSystemDbContext dbContext)
        {
            return new AccountRepository(dbContext);
        }

        public static ICategoryRepository MakeCategoryRepository(TestSystemDbContext dbContext)
        {
            return new CategoryRepository(dbContext);
        }

        public static IQuestionRepository MakeQuestionRepository(TestSystemDbContext dbContext)
        {
            return new QuestionRepository(dbContext);
        }

        public static ISubjectRepository MakeSubjectRepository(TestSystemDbContext dbContext)
        {
            return new SubjectRepository(dbContext);
        }

        public static ITestResultRepository MakeTestResultRepository(TestSystemDbContext dbContext)
        {
            return new TestResultRepository(dbContext);
        }

        public static ITestSessionRepository MakeTestSessionRepository(TestSystemDbContext dbContext)
        {
            return new TestSessionRepository(dbContext);
        }

    }
}