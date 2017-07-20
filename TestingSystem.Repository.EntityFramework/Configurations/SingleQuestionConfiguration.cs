using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class SingleQuestionConfiguration:EntityTypeConfiguration<SingleQuestion>
    {
        public SingleQuestionConfiguration()
        {
            HasKey(a => a.Id);

            Property(a => a.QuestionText).IsRequired();
            HasRequired(a => a.Subject);
            Property(a => a.Type).IsRequired();

            HasRequired(a => a.CorrectAnswer);
        }
    }
}