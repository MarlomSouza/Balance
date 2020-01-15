using System;

namespace Balance.Domain.Entities
{
    public class Budget : Entity<Budget>
    {
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        public User User { get; private set; }
        public TypeBudget TypeBudget { get; private set; }

        public Budget(string description, decimal value, int month, int year, User user, TypeBudget typeBudget)
        {
            Validade(description, value, month, year, user);

            Description = description;
            Value = value;
            Month = month;
            Year = year;
            User = user;
            TypeBudget = typeBudget;
        }

        private static void Validade(string description, decimal value, int month, int year, User user)
        {
            DomainValidator.New()
                .When(string.IsNullOrWhiteSpace(description), "It's necessary to inform the description")
                .When(description.Length > 50, "The maximum allowed for the description is 50 characters");

            DomainValidator.New()
                .When((value < 1 || value > 9999999), "The value should be between than 1 and 9999999");

            DomainValidator.New()
                .When((month < 1 || month > 12), "The month has to be between 1 and 12");

            DomainValidator.New()
                .When(year < DateTime.Now.Year - 1, "The should be greater than " + (DateTime.Now.Year - 1));

            DomainValidator.New()
                .When(user == null, "It's necessary to inform the user");
        }
    }
}