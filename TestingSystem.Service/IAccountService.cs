using System;
using System.Collections.Generic;
using TestingSystem.Dto;
using TestingSystem.Model.Accounts;

namespace TestingSystem.Service
{
    public interface IAccountService : IDomainEntityService<AccountDto>
    {
        AccountDto Identify(string email, string password);
        Guid CreateAccount(string firstName,string lastName, string email, string password, Role userRole, byte[] image);
        void ChangeFirstName(Guid accountId, string fName);
        void ChangeLastName(Guid accountId, string lName);
        void ChangePassword(Guid accountId, string newPassword);
        void ChangeEmail(Guid accountId, string newEmail);
        void ChangeRole(Guid accountId, Role newRole);
        void ChangeImage(Guid accountId, byte[] image);
        IList<Guid> ViewAllUserTests(Guid accountId);

    }
}
