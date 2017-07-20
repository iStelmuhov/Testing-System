using System.Data.Entity.ModelConfiguration;
using TestingSystem.Model.Accounts;

namespace TestingSystem.Repository.EntityFramework.Configurations
{
    public class AccountConfiguration:EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).IsRequired();

            Property(a => a.Email).IsRequired();
            Property(a => a.Password).IsRequired();
            Property(a => a.FirstName).IsRequired();
            Property(a => a.LastName).IsRequired();
            Property(a => a.Image).IsOptional();
            Property(a => a.UserRole).IsRequired();
        }
    }
}