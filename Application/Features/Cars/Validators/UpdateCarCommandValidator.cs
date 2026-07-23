using Application.Features.Cars.Commands;
using FluentValidation;

namespace Application.Features.Cars.Validators;

public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
    public UpdateCarCommandValidator()
    {
        RuleFor(x => x.UpdateCarRequest)
            .NotNull()
            .WithMessage("Car request body cannot be null.");

        When(x => x.UpdateCarRequest != null, () =>
        {
            RuleFor(x => x.UpdateCarRequest.Brand)
                .NotEmpty()
                .WithMessage("The car brand is required.");

            RuleFor(x => x.UpdateCarRequest.Model)
                .NotEmpty()
                .WithMessage("The car model is required.");

            RuleFor(x => x.UpdateCarRequest.Brand)
                .NotEmpty()
                .WithMessage("The car year is required.");
        });
    }
}
