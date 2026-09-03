using Restaurant.DTOs;
using Restaurant.DTOs.ResponseDTOs;
using Restaurant.Services.Interfaces;

public class FoodService : IFoodService
{
    public Task<CreateFoodResponse> CreateFoodAsync(
        CreateFoodRequest request,
        Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CreateFoodResponse>> GetAllFoodAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UpdateFoodResponse> UpdateFoodAsync(
        Guid foodId,
        UpdateFoodRequest request,
        Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFoodAsync(Guid foodId, Guid userId)
    {
        throw new NotImplementedException();
    }
}