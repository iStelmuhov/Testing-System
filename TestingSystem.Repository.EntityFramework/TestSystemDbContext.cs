using System.Data.Common;
using System.Data.Entity;
using TestingSystem.Model.Accounts;
using TestingSystem.Model.Questions;
using TestingSystem.Model.Session;
using TestingSystem.Repository.EntityFramework.Configurations;

namespace TestingSystem.Repository.EntityFramework
{
    public class TestSystemDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TestSession> TestSessions { get; set; }
        public DbSet<TestResult> TestResults { get; set; }

        public TestSystemDbContext()
            : base() { }

        public TestSystemDbContext(bool drop = false)
        {
            if(drop)
                Database.SetInitializer<TestSystemDbContext>(new DropCreateDatabaseAlways<TestSystemDbContext>());

            Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
        }

        public TestSystemDbContext(DbConnection connection)
            : base(connection, true)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<TestSystemDbContext>());

            Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new SimpleQuestionConfiguration());
            modelBuilder.Configurations.Add(new WriteQuestionConfiguration());
            modelBuilder.Configurations.Add(new TextOptionConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new TestInfoConfiguration());
            modelBuilder.Configurations.Add(new TestSessionConfiguration());
            modelBuilder.Configurations.Add(new TestResultConfigoration());
            base.OnModelCreating(modelBuilder);
        }
    }
}