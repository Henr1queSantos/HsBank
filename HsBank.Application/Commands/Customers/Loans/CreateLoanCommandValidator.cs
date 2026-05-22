using FluentValidation;

namespace HsBank.Application.Commands.Loans;

public class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
{
    public CreateLoanCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("The Customer ID is required.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("The loan amount must be greater than zero.");

        RuleFor(x => x.TermInMonths)
            .GreaterThan(0).WithMessage("The loan term must be at least 1 month.");
    }
}