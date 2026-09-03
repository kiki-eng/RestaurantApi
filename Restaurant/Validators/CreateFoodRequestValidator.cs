using FluentValidation;
using Restaurant.DTOs;


namespace Restaurant.Validators
{
    public class CreateFoodRequestValidator : AbstractValidator<CreateFoodRequest>
    {

        public CreateFoodRequestValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Food name is required.")
            .MaximumLength(100).WithMessage("Food name cannot exceed 100 characters.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Food type is required.")
                .MaximumLength(50).WithMessage("Food type cannot exceed 50 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Food description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}
