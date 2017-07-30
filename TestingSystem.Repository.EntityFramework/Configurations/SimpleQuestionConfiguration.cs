using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class SimpleQuestionConfiguration:EntityTypeConfiguration<SimpleQuestion>
    {
        public SimpleQuestionConfiguration()
        {
            HasKey(a => a.Id);

            Property(a => a.QuestionText).IsRequired();
            HasOptional(a => a.Subject);

        }
    }
}