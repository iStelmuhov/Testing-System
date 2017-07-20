using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using TestingSystem.Model.Session;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class TestInfoConfiguration:EntityTypeConfiguration<TestInfo>
    {
        public TestInfoConfiguration()
        {
            HasKey(a => a.Id);

            Property(a => a.SubjectId).IsRequired();
        }
    }
}