using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class CategoryConfiguration:EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(a => a.Id);

            Property(a => a.Name).IsRequired();
            Property(a => a.Description).IsOptional();
            Property(a => a.Image).IsOptional();
        }
    }
}