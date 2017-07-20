using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Session;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class TestSessionConfiguration:EntityTypeConfiguration<TestSession>
    {
        public TestSessionConfiguration()
        {
            HasKey(a => a.Id);
            HasRequired(a => a.User);
            HasRequired(a => a.TestInfo);

            Property(a => a.Duration).IsOptional();
            Property(a => a.StartTime).IsRequired();
            Property(a => a.EndTime).IsOptional();
            Property(a => a.IsEnded).IsRequired();
            HasRequired(a => a.TestInfo);
        }
    }
}