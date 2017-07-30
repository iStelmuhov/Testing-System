using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class WriteQuestionConfiguration:EntityTypeConfiguration<WriteQuestion>
    {
        public WriteQuestionConfiguration()
        {
            HasKey(a => a.Id);

            Property(a => a.QuestionText).IsRequired();
            HasRequired(a => a.Subject);

        }
    }
}