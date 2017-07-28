using System;
using System.Collections.Generic;
using TestingSystem.Model.Accounts;

namespace TestingSystem.Dto
{
    public class AccountDto:DomainEntityDto<AccountDto>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Role UserRole { get; private set; }
        public string Email { get; private set; }
        public byte[] Image { get; private set; }

        public AccountDto(Guid domainId, string firstName, string lastName, Role userRole, string email, byte[] image) 
            : base(domainId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserRole = userRole;
            Email = email;
            Image = image;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] {FirstName,LastName,Email };
        }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(UserRole)}: {UserRole}, {nameof(Email)}: {Email}";
        }
    }
}