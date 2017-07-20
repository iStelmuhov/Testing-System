using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class MultiQuestionConfiguration:EntityTypeConfiguration<MultiQestion>
    {
        public MultiQuestionConfiguration()
        {
            HasKey(a => a.Id);

            Property(a => a.QuestionText).IsRequired();
            HasRequired(a => a.Subject);
            Property(a => a.Type).IsRequired();

        }
    }
}