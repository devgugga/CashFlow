﻿using CashFlow.Communication.Requests;
using CashFlow.Communication.responses;
using CashFlow.Domain;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.BaseExceptions;

namespace CashFlow.Application.UseCases.Expenses.Register;

internal class RegisterExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork) : IRegisterExpenseUseCase
{
    public async Task<ResponseRegisterExpenseJson> Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        var entity = new Expense
        {
            Title = request.Title,
            Description = request.Description,
            Value = request.Value,
            Date = request.Date,
            PaymentType = (PaymentType)request.PaymentType
        };

        await repository.Add(entity);

        await unitOfWork.Commit();

        var response = new ResponseRegisterExpenseJson
        {
            Title = request.Title
        };

        return response;
    }

    private static void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);
    }
}