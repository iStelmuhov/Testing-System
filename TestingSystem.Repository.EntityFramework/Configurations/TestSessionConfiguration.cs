using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Session;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class TestSessionConfiguration:EntityTypeConfiguration<TestSession>
    {
        public TestSessionConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.UserId).IsRequired();
            HasOptional(a => a.TestInfo);

            Property(a => a.Duration).IsOptional();
            Property(a => a.StartTime).IsOptional();
            Property(a => a.EndTime).IsOptional();
            Property(a => a.IsEnded).IsOptional();
            
        }
    }
}