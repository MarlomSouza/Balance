namespace Balance.API.Dtos
{
    public class BudgetDto
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string UserName { get; set; }
        public int TypeBudget { get; set; }
    }
}