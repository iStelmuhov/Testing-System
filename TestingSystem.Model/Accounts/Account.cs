using System;

namespace TestingSystem.Model.Accounts
{
    public class Account
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role UserRole { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }

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