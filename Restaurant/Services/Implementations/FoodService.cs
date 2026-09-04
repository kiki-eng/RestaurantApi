using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.DTOs.ResponseDTOs;
using Restaurant.Entities;
using Restaurant.Services.Interfaces;

public class FoodService : IFoodService
{

    private readonly ApplicationDbContext _context;
    public FoodService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CreateFoodResponse> CreateFoodAsync(CreateFoodRequest request, Guid userId)
    {

        var food = new Food
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Type = request.Type,
            Price = request.Price,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow,
            CreatedByUserId = userId,
            IsDeleted = false   
        };

        _context.Foods.Add(food);

        await _context.SaveChangesAsync();

        return new CreateFoodResponse
        {
            Id = food.Id,
            Name = food.Name,
            Type = food.Type,
            Price = food.Price,
            Description = food.Description,

        };


    }

    public async Task<IEnumerable<CreateFoodResponse>> GetAllFoodAsync(Guid userId)
    {
        var foods = await _context.Foods
            .Where(f=> f.CreatedByUserId == userId && !f.IsDeleted)
            .Select(f => new CreateFoodResponse
            {
                Id = f.Id,
                Name = f.Name,
                Type = f.Type,
                Price = f.Price,
                Description = f.Description
            })
            .ToListAsync();

        return foods;
    }

    public async Task<UpdateFoodResponse> UpdateFoodAsync( Guid foodId, UpdateFoodRequest request,Guid userId)
    {
        var food = await _context.Foods
        .FirstOrDefaultAsync(f =>
        f.Id == foodId &&
        f.CreatedByUserId == userId &&
        !f.IsDeleted);
        
        if(food == null)
        {
            throw new Exception("Food not found");
        }
        food.Name = request.Name;
        food.Type = request.Type;
        food.Price = request.Price;
        food.Description = request.Description;

        food.UpdatedAt = DateTime.UtcNow;
        food.UpdatedByUserId = userId;

        await _context.SaveChangesAsync();

        return new UpdateFoodResponse
        {
            Id = food.Id,
            Name = food.Name,
            Type = food.Type,
            Price = food.Price,
            Description = food.Description
        };

    }

    public async Task DeleteFoodAsync(Guid foodId, Guid userId)
    {
        var food = await _context.Foods
            .FirstOrDefaultAsync(f =>
            f.Id == foodId &&
            f.CreatedByUserId == userId &&
            !f.IsDeleted);

        if (food == null)
        {
            throw new Exception("Food not found");
        }

        food.IsDeleted = true;
        food.DeletedAt = DateTime.UtcNow;
        food.DeletedByUserId = userId;

        await _context.SaveChangesAsync();
    }
}