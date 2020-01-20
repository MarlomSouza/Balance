using System;
using System.Threading.Tasks;
using Balance.API.Dtos;
using Balance.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Balance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(UserDto dto)
        {
            _service.Add(dto);
            return Created("", dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var user = await _service.GetByIdAsync(id);
            return new JsonResult(user);
        }


        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _service.GetAsync();
            return new JsonResult(users);
        }
    }
}