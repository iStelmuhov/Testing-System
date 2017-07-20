using System.Linq;
using TestingSystem.Model.Accounts;

namespace TestingSystem.Repository
{
    public interface IAccountRepository:IRepository<Account>
    {
        IQueryable<Account> FindByName(string firstName, string lastName);
        Account FindByEmail(string email);
    }
}