using CashFlow.Communication.Requests;
using CashFlow.Communication.responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        // TODO: Validate request
        
        return new ResponseRegisterExpenseJson();
    }
}