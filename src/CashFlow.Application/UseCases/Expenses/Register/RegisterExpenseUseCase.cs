using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.responses;

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
        // Verifica se o título é vazio, nulo ou contem uma sequência de espaços.
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
        {
            // Se o título for vazio joga uma exceção.
            throw new ArgumentException("The title is required.");
        }
        // Verifica se o valor é maior que zero.
        if (request.Value <= 0)
        {
            // Se o valor for menor ou igual a zero joga uma exceção.
            throw new ArgumentException("Value must be greater than 0.");
        }

        // Compara se a data passada por request é "maior" do que a data atual se for ele ira retornar algo maior que zero.
        var dateResult = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (dateResult > 0)
        {
            // Se a data for no futuro então joga uma exceção.
            throw new ArgumentException("Expenses can't be in register in the future.");
        }

        // Verifica se o tipo de pagamento existe no Enum Payment Type se existir ele retorna "true".
        var paymentTypeResult = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if (!paymentTypeResult)
        {
            // Se o tipo de pagamento fo invalido joga uma exceção.
            throw new ArgumentException("This payment type is not register in our application.");
        }
    }
}