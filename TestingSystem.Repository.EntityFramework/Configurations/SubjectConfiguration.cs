using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class SubjectConfiguration:EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration()
        {
            HasKey(a => a.Id);

            Property(a => a.Description).IsOptional();
            Property(a => a.Image).IsOptional();
            HasRequired(a => a.Category);
            Property(a => a.Name).IsRequired();
            Property(a => a.MaxDuration).IsRequired();

        }
    }
}