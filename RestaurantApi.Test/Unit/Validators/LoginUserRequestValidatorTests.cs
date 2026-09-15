using FluentValidation.TestHelper;
using Restaurant.DTOs;
using Restaurant.Validators;

namespace RestaurantApi.Test.Unit.Validators
{
    public class LoginUserRequestValidatorTests
    {
        private readonly LoginUserRequestValidator _validator;

        public LoginUserRequestValidatorTests()
        {
            _validator = new LoginUserRequestValidator();
        }


        private static LoginUserRequest CreateValidRequest()
        {
            return new LoginUserRequest
            {
                Email = "test@example.com",
                Password = "Password123"
            };
        }

        [Fact]
        public void Email_WhenEmpty_ShouldHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Email = "";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Email_WhenInvalid_ShouldHaveValidationError()
        {
            var model = CreateValidRequest();
            model.Email = "invalid-email";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }
    }
}
