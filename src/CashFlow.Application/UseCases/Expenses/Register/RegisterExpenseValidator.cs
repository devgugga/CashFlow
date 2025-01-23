using CashFlow.Communication.Requests;
using CashFlow.Exception.Resources;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage(ErrorMessagesResource.TitleIsRequired);
        RuleFor(expense => expense.Value).GreaterThan(0).WithMessage(ErrorMessagesResource.ValueCantBeZero);
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ErrorMessagesResource.ExpenseCantBeInTheFuture);
        RuleFor(expense => expense.PaymentType).IsInEnum()
            .WithMessage(ErrorMessagesResource.PaymentTypeNotRegister);
    }
}
