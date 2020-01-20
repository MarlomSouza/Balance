using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Balance.API.Dtos;
using Balance.Domain;
using Balance.Domain.Base;
using Balance.Domain.Entities;

namespace Balance.API.Services
{
    public class BudgetService
    {
        private readonly IRepository<Budget> _repository;
        private readonly IUserRepository _userRepository;

        public BudgetService(IRepository<Budget> repository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _repository = repository;
        }

        public async Task AddAsync(BudgetDto dto)
        {
            var typeBudget = (TypeBudget)dto.TypeBudget;

            var user = await _userRepository.GetByNameAsync(dto.Username);

            if (user == null)
                throw new Exception("User don't exist");

            var budget = new Budget(dto.Description, dto.Value, dto.DateTime, typeBudget, user);

            user.AddNewBudget(budget);

            _repository.AddAsync(budget);
            _userRepository.UpdateAsync(user);
        }

        public async Task<Budget> GetByIdAsync(string id)
        {
            var budget = await _repository.GetByIdAsync(id);
            if (budget == null)
                throw new Exception("Budget don't exist");

            return budget;
        }

        public async Task<IEnumerable<Budget>> GetAllAsync()
        {
            var budgets = await _repository.GetAllAsync();
            return budgets;
        }
    }
}