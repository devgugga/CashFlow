using CashFlow.Domain;

namespace CashFlow.Infrastructure.DataAccess;

internal class UnitOfWork(CashFlowDbContext context) : IUnitOfWork
{
    public void Commit()
    {
        context.SaveChanges();
    }
}