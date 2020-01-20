using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Balance.API.Dtos;
using Balance.API.Services;
using Balance.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Balance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly BudgetService _service;

        public BudgetController(BudgetService budgetService)
        {
            _service = budgetService;
        }

        [HttpGet]
        public async Task<IEnumerable<Budget>> GetAsync() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<Budget> GetAsync(string id) => await _service.GetByIdAsync(id);

        [HttpPost]
        public async Task<IActionResult> PostAsync(BudgetDto dto)
        {
            await _service.AddAsync(dto);
            return Created("", dto);
        }
    }
}