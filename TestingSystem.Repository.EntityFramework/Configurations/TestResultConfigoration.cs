using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Session;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class TestResultConfigoration:EntityTypeConfiguration<TestResult>
    {
        public TestResultConfigoration()
        {
            HasKey(a => a.Id);

            Property(a => a.UserId).IsRequired();
            Property(a => a.Score).IsRequired();
            Property(a => a.TestSessionId).IsRequired();
        }
    }
}