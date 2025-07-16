using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business.IServices;
using TaskManager.Business.ServiceModels;
using TaskManager.Data.Entities.Modles;
using TaskManager.Data.IRepository;
using TodoApp.UtilitiesAndConstants;
namespace TaskManager.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

       

        public async Task<string> LoginAsync(string username, string password)
        {
           var user = await _userRepository.GetByUsername(username);
            if (user == null || !PasswordHasher.Verify(password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }
            var token = _jwtService.GenerateToken(user.Id.GetHashCode(), user.Username);
            return token;
        

        }

        public async Task<UserServiceModels> RegisterAsync(string username, string password, string email)
        {
            var hashedPassword = PasswordHasher.Hash(password);
            var user = new User
            {
                Username = username,
                PasswordHash = hashedPassword,
                Email = email
            };

            var registerUser = await _userRepository.RegisterAsync(user);
            return new UserServiceModels
            {
                Id = registerUser.Id.GetHashCode(),
                Username = registerUser.Username,
                Email = registerUser.Email
            };
        }
    }
}
