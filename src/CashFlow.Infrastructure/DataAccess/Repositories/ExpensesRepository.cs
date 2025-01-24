using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository(CashFlowDbContext context) : IExpensesRepository
{
    public async Task Add(Expense expense)
    {
        await context.Expenses.AddAsync(expense);
    }
}