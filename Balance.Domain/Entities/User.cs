using System.Collections.Generic;
using Balance.Domain.VOs;

namespace Balance.Domain.Entities
{
    public class User : Entity<User>
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public IList<Budget> Budgets { get; private set; }

        public User(string name, Email email, string password)
        {
            Validade(name, email, password);

            Name = name;
            Email = email;
            Password = password;
            Budgets = new List<Budget>();

        }
        private static void Validade(string name, Email email, string password)
        {
            DomainValidator.New()
                            .When(string.IsNullOrEmpty(name), "Name is required")
                            .When(name.Length > 25, "The maximum allowed for the user name is 25 characters.")
                            .When(email == null, "Email is required")
                            .When(string.IsNullOrEmpty(password), "Password is required")
                            .When(password.Length < 8, "Password is not strong enough");
        }

        public void AddNewBudget(Budget budget)
        {
            DomainValidator.New().When(budget == null, "Invalid Budget");

            Budgets.Add(budget);
        }
    }
}