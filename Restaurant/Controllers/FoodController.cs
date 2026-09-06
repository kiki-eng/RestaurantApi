using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.Interfaces;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodservice;
        public FoodController(IFoodService foodService)
        {
            _foodservice = foodService;
        }
    }

}
