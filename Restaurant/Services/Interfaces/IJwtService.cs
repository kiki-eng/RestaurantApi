using Restaurant.Entities;

namespace Restaurant.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
