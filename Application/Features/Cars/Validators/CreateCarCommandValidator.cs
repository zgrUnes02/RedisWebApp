using Application.Features.Cars.Commands;
using FluentValidation;

namespace Application.Features.Cars.Validators;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(x => x.CreateCarRequest)
             .NotNull()
             .WithMessage("Car request body cannot be null.");

        When(x => x.CreateCarRequest != null, () =>
        {
            RuleFor(x => x.CreateCarRequest.Brand)
                .NotEmpty()
                .WithMessage("The car brand is required.");

            RuleFor(x => x.CreateCarRequest.Model)
                .NotEmpty()
                .WithMessage("The car model is required.");

            RuleFor(x => x.CreateCarRequest.Brand)
                .NotEmpty()
                .WithMessage("The car year is required.");
        });
    }
}
