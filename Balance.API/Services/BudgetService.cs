using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Balance.API.Dtos;
using Balance.Domain.Base;
using Balance.Domain.Entities;

namespace Balance.API.Services
{
    public class BudgetService
    {
        private readonly IRepository<Budget> _repository;

        public BudgetService(IRepository<Budget> repository)
        {
            _repository = repository;
        }

        public void Add(BudgetDto dto)
        {
            var typeBudget = (TypeBudget)dto.TypeBudget;
            var budget = new Budget(dto.Description, dto.Value, dto.Month, dto.Year, dto.UserName, typeBudget);

            _repository.AddAsync(budget);
        }

        public async Task<Budget> FindByIdAsync(string id)
        {
            var budget = await _repository.GetByIdAsync(id);
            if (budget == null)
                throw new Exception("Budget don't exist");

            return budget;
        }

        public async Task<IEnumerable<Budget>> FindAll()
        {
            var budgets = await _repository.GetAllAsync();
            if (budgets == null)
                throw new Exception("Budget don't exist");

            return budgets;
        }
    }
}