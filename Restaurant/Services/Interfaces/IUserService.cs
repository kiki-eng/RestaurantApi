using Restaurant.DTOs;
using Restaurant.DTOs.ResponseDTOs;

namespace Restaurant.Services.Interfaces
{
    public interface IUserService
    {
        Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request);
        Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request);
    }
}
