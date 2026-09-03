using Restaurant.DTOs.ResponseDTOs;
using Restaurant.DTOs;

namespace Restaurant.Services.Interfaces
{
    public interface IFoodService
    {
        Task<CreateFoodResponse> CreateFoodAsync(CreateFoodRequest request, Guid userId);

        Task<IEnumerable<CreateFoodResponse>> GetAllFoodAsync();

        Task<UpdateFoodResponse> UpdateFoodAsync(Guid foodId, UpdateFoodRequest request, Guid userId);

        Task DeleteFoodAsync(Guid foodId, Guid userId);
    }
}
