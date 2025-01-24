using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository(CashFlowDbContext context) : IExpensesRepository
{
    public void Add(Expense expense)
    {
        context.Expenses.Add(expense);
        context.SaveChanges();
    }
}