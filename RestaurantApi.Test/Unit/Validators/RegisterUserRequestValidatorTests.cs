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

        [Fact]
        public void Name_WhenMoreThan100Characters_ShouldHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = new string('A', 101),
                Email = "test@example.com",
                Password = "Password123",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Name_WhenExactly100Characters_ShouldNotHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = new string('A', 100),
                Email = "test@example.com",
                Password = "Password123",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Email_WhenEmpty_ShouldHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "",
                Password = "Password123",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Email_WhenInvalid_ShouldHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "invalid-email",
                Password = "Password123",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }
        [Fact]
        public void Email_WhenValid_ShouldNotHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Password = "Password123",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }
        [Fact]
        public void Password_WhenEmpty_ShouldHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Password = "",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Password_WhenLessThan8Characters_ShouldHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Password = "Pass123",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Password_WhenExactly8Characters_ShouldNotHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Password = "Pass1234",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }
        [Fact]
        public void Location_WhenEmpty_ShouldHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Password = "Password123",
                Location = ""
            };

            var result = _request.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Location);
        }

        [Fact]
        public void Location_WhenValid_ShouldNotHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Password = "Password123",
                Location = "Toronto"
            };

            var result = _request.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Location);
        }

        [Fact]
        public void Location_WhenMoreThan100Characters_ShouldHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Password = "Password123",
                Location = new string('A', 101)
            };

            var result = _request.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Location);
        }

        [Fact]
        public void Location_WhenExactly100Characters_ShouldNotHaveValidationError()
        {
            var model = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Password = "Password123",
                Location = new string('A', 100)
            };

            var result = _request.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Location);
        }

    }
}
