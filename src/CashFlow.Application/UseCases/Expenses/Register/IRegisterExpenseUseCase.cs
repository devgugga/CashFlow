using CashFlow.Communication.Requests;
using CashFlow.Communication.responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public interface IRegisterExpenseUseCase
{
    Task<ResponseRegisterExpenseJson> Execute(RequestRegisterExpenseJson request);
}