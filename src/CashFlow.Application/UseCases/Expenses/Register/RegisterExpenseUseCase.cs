using CashFlow.Communication.Requests;
using CashFlow.Communication.responses;
using CashFlow.Exception.BaseExceptions;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        return new ResponseRegisterExpenseJson();
    }

    public void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);
    }
}