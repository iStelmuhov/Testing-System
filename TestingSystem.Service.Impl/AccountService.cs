using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using TestingSystem.Model.Accounts;
using TestingSystem.Repository;


namespace TestingSystem.Service.Impl
{
    public class AccountService:IAccountService
    {
        [Dependency]
        protected IAccountRepository accountRepository { get; set; }

        public IList<Guid> ViewAll()
        {
            return accountRepository.SelectAllDomainIds().ToList();
        }

        public Account View(Guid domainId)
        {
            Account ac = ResolveAccount(domainId);
            return ac;
        }

        public Account Identify(string email, string password)
        {
            Account ac = accountRepository.FindByEmail(email);
            if (ac == null)
                return null;

            if (!ac.CheckPassword(password))
                return null;

            return ac;
        }

        public void ChangeFirstName(Guid accountId, string fName)
        {
            throw new NotImplementedException();
        }

        public void ChangeLastName(Guid accountId, string lName)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(Guid accountId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void ChangeEmail(Guid accountId, string newEmaill)
        {
            throw new NotImplementedException();
        }

        public void ChangeRole(Guid accountId, string newRole)
        {
            throw new NotImplementedException();
        }

        public IList<Guid> ViewAllUserTests(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public Guid CreateAccount(string name, string email, string password, string fName, string lName, Role userRole)
        {
            throw new NotImplementedException();
        }

        private Account ResolveAccount(Guid accountId)
        {
            return ServiceUtils.ResolveEntity(accountRepository, accountId);
        }
    }
}
