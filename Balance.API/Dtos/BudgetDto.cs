using System;

namespace Balance.API.Dtos
{
    public class BudgetDto
    {
        public string Description { get; set; }
        public string Username { get; set; }
        public decimal Value { get; set; }
        public DateTime DateTime { get; set; }
        public int TypeBudget { get; set; }
    }
}