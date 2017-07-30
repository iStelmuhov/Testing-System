using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using TestingSystem.Dto;
using TestingSystem.Exceptions.DomainLogic;
using TestingSystem.Model.Accounts;
using TestingSystem.Repository;


namespace TestingSystem.Service.Impl
{
    public class AccountService:IAccountService
    {
        [Dependency]
        protected IAccountRepository accountRepository { get; set; }

        [Dependency]
        protected ITestResultRepository testResultRepository { get; set; }

        public IList<Guid> ViewAll()
        {
            return accountRepository.SelectAllDomainIds().ToList();
        }

        public AccountDto View(Guid domainId)
        {
            Account ac = ResolveAccount(domainId);
            return ac.ToDto();
        }

        public void Hide(Guid domainId)
        {
            Account account = ResolveAccount(domainId);
            account.Hide();
        }

        public void Unhide(Guid domainId)
        {
            Account account = ResolveAccount(domainId);
            account.UnHide();
        }

        public AccountDto Identify(string email, string password)
        {
            Account ac = accountRepository.FindByEmail(email);
            if (ac == null)
                return null;

            if (!ac.CheckPassword(password))
                return null;

            return ac.ToDto();
        }

        public void ChangeFirstName(Guid accountId, string fName)
        {
            Account account = ResolveAccount(accountId);
            account.FirstName = fName;
        }

        public void ChangeLastName(Guid accountId, string lName)
        {
            Account account = ResolveAccount(accountId);
            account.LastName = lName;
        }

        public void ChangePassword(Guid accountId, string newPassword)
        {
            Account account = ResolveAccount(accountId);
            account.Password = newPassword;
        }

        public void ChangeEmail(Guid accountId, string newEmail)
        {
            Account account = accountRepository.FindByEmail(newEmail);
            if (account != null)
                throw new DuplicateNamedEntityException(typeof(Account), newEmail);

            account = ResolveAccount(accountId);
            account.Email = newEmail;
        }

        public void ChangeRole(Guid accountId, Role newRole)
        {
            Account account = ResolveAccount(accountId);
            account.UserRole = newRole;
        }

        public void ChangeImage(Guid accountId, byte[] image)
        {
            Account account = ResolveAccount(accountId);
            account.Image = image;
        }

        public IList<Guid> ViewAllUserTests(Guid accountId)
        {
            return testResultRepository.FindAllUserTestResults(accountId).Select(a => a.Id).ToList();
        }

        public Guid CreateAccount(string firstName,string lastName, string email, string password, Role userRole, byte[] image)
        {
            Account a = accountRepository.FindByEmail(email);
            if (a != null)
                throw new DuplicateNamedEntityException(typeof(Account), email);

            Account account =new Account(Guid.NewGuid(),firstName,lastName, userRole,password,email, image);
            accountRepository.Add(account);

            return account.Id;
        }

        private Account ResolveAccount(Guid accountId)
        {
            return ServiceUtils.ResolveEntity(accountRepository, accountId);
        }
    }
}
