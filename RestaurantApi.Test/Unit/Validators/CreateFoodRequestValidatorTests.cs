using Restaurant.DTOs;
using Restaurant.Validators;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace RestaurantApi.Test.Unit.Validators
{
    public class CreateFoodRequestValidatorTests
    {
        private readonly CreateFoodRequestValidator _validators;
        public CreateFoodRequestValidatorTests()
        { 
            _validators = new CreateFoodRequestValidator();

        }

        [Fact]
        public void Name_WhenEmpty_ShouldHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "",
                Type = "Main",
                Price = 10,
                Description = "Test food"
            };

        }
        [Fact]
        public void Name_WhenValid_ShouldNotHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Jollof Rice",
                Type = "Main",
                Price = 10,
                Description = "Test food"
            };
        }

        public void Price_WhenZero_ShouldHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Jollof Rice",
                Type = "Main",
                Price = 0,
                Description = "Test food"

            };
        }
    }
}
