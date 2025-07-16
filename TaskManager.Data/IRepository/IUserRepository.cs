using TaskManager.Data.Entities.Modles;

namespace TaskManager.Data.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetByUsername(string username);
        Task<User> RegisterAsync(User user);
    }
}