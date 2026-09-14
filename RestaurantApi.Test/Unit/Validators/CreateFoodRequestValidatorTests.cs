using FluentValidation.TestHelper;
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

            var result = _validators.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Name);

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

            var result = _validators.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Price_WhenZero_ShouldHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Jollof Rice",
                Type = "Main",
                Price = 0,
                Description = "Test food"

            };
            var result = _validators.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Price);

        }

        [Fact]
        public void ValidRequest_ShouldNotHaveAnyValidationErrors()
        {
            var model = new CreateFoodRequest
            {
                Name = "Jollof Rice",
                Type = "Main",
                Price = 15.50m,
                Description = "Delicious rice dish"
            };

            var result = _validators.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Price_WhenNegative_ShouldHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Test Food",
                Type = "Main Course",
                Price = -1,
                Description = "Valid food description"
            };

            var result = _validators.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Price_WhenValid_ShouldNotHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Test Food",
                Type = "Main Course",
                Price = 10.00m,
                Description = "Valid food description"
            };

            var result = _validators.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Type_WhenEmpty_ShouldHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Test Food",
                Type = "",
                Price = 10.00m,
                Description = "Valid food description"
            };

            var result = _validators.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Type);
        }

        [Fact]
        public void Type_WhenValid_ShouldNotHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Test Food",
                Type = "Main Course",
                Price = 10.00m,
                Description = "Valid food description"
            };

            var result = _validators.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Type);
        }

        [Fact]
        public void Type_WhenMoreThan50Characters_ShouldHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Test Food",
                Type = new string('A', 51),
                Price = 10.00m,
                Description = "Valid food description"
            };

            var result = _validators.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Type);
        }

        [Fact]
        public void Type_WhenExactly50Characters_ShouldNotHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Test Food",
                Type = new string('A', 50),
                Price = 10.00m,
                Description = "Valid food description"
            };

            var result = _validators.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Type);
        }

        [Fact]
        public void Description_WhenEmpty_ShouldHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Test Food",
                Type = "Main Course",
                Price = 10.00m,
                Description = ""
            };

            var result = _validators.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Description_WhenValid_ShouldNotHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Test Food",
                Type = "Main Course",
                Price = 10.00m,
                Description = "Valid food description"
            };

            var result = _validators.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Description_WhenMoreThan500Characters_ShouldHaveValidationError()
        {
            var model = new CreateFoodRequest
            {
                Name = "Test Food",
                Type = "Main Course",
                Price = 10.00m,
                Description = new string('A', 501)
            };

            var result = _validators.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Description);
        }
    }
}
