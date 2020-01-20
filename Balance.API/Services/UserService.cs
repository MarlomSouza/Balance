using System.Collections.Generic;
using System.Threading.Tasks;
using Balance.API.Dtos;
using Balance.Domain;
using Balance.Domain.Entities;
using Balance.Domain.VOs;

namespace Balance.API.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Add(UserDto dto)
        {
            var email = new Email(dto.Email);

            var user = new User(dto.Name, email, dto.Password);

            dto.Id = user.Id;
            _repository.AddAsync(user);
        }
        

        public async Task<User> GetByIdAsync(string id) => await _repository.GetByIdAsync(id);

        public async Task<User> GetByNameAsync(string name) => await _repository.GetByNameAsync(name);

        public async Task<IEnumerable<User>> GetAsync() => await _repository.GetAllAsync();
    }
}