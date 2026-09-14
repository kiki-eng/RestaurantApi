using Restaurant.DTOs;
using Restaurant.Validators;
using FluentValidation.TestHelper;


namespace RestaurantApi.Test.Unit.Validators
{
    public class RegisterUserRequestValidatorTests
    {

        private readonly RegisterUserRequestValidator _request;

        public RegisterUserRequestValidatorTests()
        {
            _request = new RegisterUserRequestValidator();
        }

        [Fact]
        public void Name_WhenValid_ShouldNotHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Password = "Password123",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Name_WhenEmpty_ShouldHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "",
                Email = "test@example.com",
                Password = "Password123",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

    }
}
