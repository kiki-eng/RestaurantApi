using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTOs;
using Restaurant.Services;
using Restaurant.Services.Interfaces;
using System.Security.Claims;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood(CreateFoodRequest request)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

            var response = await _foodService.CreateFoodAsync(request, userId);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFood()
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

            var response = await _foodService.GetAllFoodAsync(userId);

            return Ok(response);
        }

        [HttpPut("{foodId}")]
        public async Task<IActionResult> UpdateFood(
            Guid foodId,
            UpdateFoodRequest request)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

            var response = await _foodService.UpdateFoodAsync(
                foodId,
                request,
                userId
            );

            return Ok(response);
        }

        [HttpDelete("{foodId}")]
        public async Task<IActionResult> DeleteFood(Guid foodId)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

            await _foodService.DeleteFoodAsync(foodId, userId);

            return NoContent();
        }
    }
}