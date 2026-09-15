using FluentValidation.TestHelper;
using Restaurant.DTOs;
using Restaurant.Validators;

namespace RestaurantApi.Test.Unit.Validators
{
    public class CreateFoodRequestValidatorTests
    {
        private readonly CreateFoodRequestValidator _validator;

        public CreateFoodRequestValidatorTests()
        {
            _validator = new CreateFoodRequestValidator();
        }

        private static CreateFoodRequest CreateValidRequest()
        {
            return new CreateFoodRequest
            {
                Name = "Test Food",
                Type = "Main Course",
                Price = 10.00m,
                Description = "Valid food description"
            };
        }

        [Fact]
        public void Name_WhenEmpty_ShouldHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Name = "";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Name_WhenValid_ShouldNotHaveValidationError()
        {
            var model = CreateValidRequest();

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Name_WhenExactly100Characters_ShouldNotHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Name = new string('A', 100);

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Name_WhenMoreThan100Characters_ShouldHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Name = new string('A', 101);

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Price_WhenZero_ShouldHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Price = 0;

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Price_WhenNegative_ShouldHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Price = -1;

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Price_WhenValid_ShouldNotHaveValidationError()
        {
            var model = CreateValidRequest();

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Type_WhenEmpty_ShouldHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Type = "";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Type);
        }

        [Fact]
        public void Type_WhenValid_ShouldNotHaveValidationError()
        {
            var model = CreateValidRequest();

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Type);
        }

        [Fact]
        public void Type_WhenMoreThan50Characters_ShouldHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Type = new string('A', 51);

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Type);
        }

        [Fact]
        public void Type_WhenExactly50Characters_ShouldNotHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Type = new string('A', 50);

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Type);
        }

        [Fact]
        public void Description_WhenEmpty_ShouldHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Description = "";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Description_WhenValid_ShouldNotHaveValidationError()
        {
            var model = CreateValidRequest();

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Description_WhenMoreThan500Characters_ShouldHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Description = new string('A', 501);

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Description_WhenExactly500Characters_ShouldNotHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Description = new string('A', 500);

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void ValidRequest_ShouldNotHaveAnyValidationErrors()
        {
            var model = CreateValidRequest();

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}