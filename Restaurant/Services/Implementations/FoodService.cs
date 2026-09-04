using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.DTOs.ResponseDTOs;
using Restaurant.Entities;
using Restaurant.Services.Interfaces;

public class FoodService : IFoodService
{
    public Task<CreateFoodResponse> CreateFoodAsync(CreateFoodRequest request, Guid userId)
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


    }

    public Task<IEnumerable<CreateFoodResponse>> GetAllFoodAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UpdateFoodResponse> UpdateFoodAsync( Guid foodId, UpdateFoodRequest request,Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFoodAsync(Guid foodId, Guid userId)
    {
        throw new NotImplementedException();
    }
}