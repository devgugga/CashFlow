using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

internal class CashFlowDbContext(DbContextOptions<CashFlowDbContext> options) : DbContext(options)
{
    internal DbSet<Expense> Expenses { get; set; }
}