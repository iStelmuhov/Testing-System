using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Model.Accounts;

namespace TestingSystem.Service
{
    public interface IAccountService : IDomainEntityService<Account>
    {
        Account Identify(string email, string password);
        Guid CreateAccount(string name, string email, string password, string fName, string lName, Role userRole);
        void ChangeFirstName(Guid accountId, string fName);
        void ChangeLastName(Guid accountId, string lName);
        void ChangePassword(Guid accountId, string newPassword);
        void ChangeEmail(Guid accountId, string newEmaill);
        void ChangeRole(Guid accountId, string newRole);
        IList<Guid> ViewAllUserTests(Guid accountId);

    }
}
