using System;

namespace Balance.Domain.Entities
{
    public class Budget : Entity<Budget>
    {
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public DateTime DateTime { get; private set; }
        public User User { get; private set; }
        public TypeBudget TypeBudget { get; private set; }

        public Budget(string description, decimal value, DateTime date, TypeBudget typeBudget, User user)
        {
            Validade(description, value, date, user);

            Description = description;
            Value = value;
            DateTime = date;
            TypeBudget = typeBudget;
            User = user;
        }

        private static void Validade(string description, decimal value, DateTime date, User user)
        {
            DomainValidator.New()
                .When(string.IsNullOrWhiteSpace(description), "It's necessary to inform the description")
                .When(description.Length > 50, "The maximum allowed for the description is 50 characters");

            DomainValidator.New()
                .When((value < 1 || value > 9999999), "The value should be between than 1 and 9999999");

            DomainValidator.New()
                .When(date < DateTime.Now.AddYears(-1), "The should be greater than " + DateTime.Now.AddYears(-1));

            DomainValidator.New()
                .When(user == null, "User is inválid");
        }
    }
}