using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required and can't be empty.");
        RuleFor(expense => expense.Value).GreaterThan(0).WithMessage("Value must be greater than zero.");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses can't be in register in the future.");
        RuleFor(expense => expense.PaymentType).IsInEnum()
            .WithMessage("This payment type is not register in our application.");
    }
}
