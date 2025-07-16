

using TaskManager.Business.ServiceModels;

namespace TaskManager.Business.IServices
{
    public interface IUserService
    {
        Task<string> LoginAsync(string username, string password);
        Task<UserServiceModels> RegisterAsync(string username, string password, string email);
    }
}