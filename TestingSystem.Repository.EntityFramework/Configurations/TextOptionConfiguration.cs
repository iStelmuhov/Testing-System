using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class TextOptionConfiguration:EntityTypeConfiguration<TextOption>
    {
        public TextOptionConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Text).IsRequired();
            Property(a => a.IsCorrect).IsRequired();
        }
    }
}