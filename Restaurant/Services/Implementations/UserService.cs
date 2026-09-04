using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.DTOs.ResponseDTOs;
using Restaurant.Entities;
using Restaurant.Services.Interfaces;

namespace Restaurant.Services.Implementations
{
    public class UserService: IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

       public async Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if(existingUser != null)
            {

                throw new Exception("User with this email already exists");

            }
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Location = request.Location,
                Passwordhash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return new RegisterUserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Location = user.Location
            };
        }

        







        public async Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if(user == null)
            {
                throw new Exception("Invalid Email or Exception");
            }

            var passwordIsValid = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.Passwordhash);

            if (!passwordIsValid)
            {
                throw new Exception("Invalid Email or password");
            }

            return new LoginUserResponse
            {
                Token = "temporary-token",
                ExpiresAt = DateTime.UtcNow.AddHours(1)
            };
        }
    }
}
