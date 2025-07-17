namespace TaskManager.Business.IServices
{
    public interface IJwtService
    {
        string GenerateToken(Guid userId, string username);
    }
}