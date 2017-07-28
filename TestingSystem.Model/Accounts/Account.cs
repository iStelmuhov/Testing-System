using System;

namespace TestingSystem.Model.Accounts
{
    public class Account : Utils.Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role UserRole { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }

        protected Account(){}

        public Account(Guid domainId, string firstName, string lastName, Role userRole, string password, string email, byte[] image) 
            : base(domainId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserRole = userRole;
            Password = password;
            Email = email;
            Image = image;
        }

        public bool CheckPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            return Password == password;
        }
        public void ChangePassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            Password = password;
        }
    }
}