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
        private readonly IConfiguration _configuration;

        public BudgetController(BudgetService budgetService, IConfiguration configuration)
        {
            _service = budgetService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IEnumerable<Budget>> GetAsync() => await _service.FindAll();

        [HttpGet("{id}")]
        public async Task<Budget> GetAsync(string id) => await _service.FindByIdAsync(id);

        [HttpPost]
        public void Post(BudgetDto dto) => _service.Add(dto);
    }
}