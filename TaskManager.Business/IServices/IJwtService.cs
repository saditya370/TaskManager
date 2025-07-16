namespace TaskManager.Business.IServices
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string username);
    }
}