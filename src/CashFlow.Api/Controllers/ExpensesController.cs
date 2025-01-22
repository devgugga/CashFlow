﻿using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;
[Route("api/expenses")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        try
        {
            var useCase = new RegisterExpenseUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ArgumentException ex)
        {
            var errorResponse = new ResponseErrorJson
            {
                ErrorMessage = ex.Message
            };

            return BadRequest(errorResponse);
        }
        catch
        {
            var errorResponse = new ResponseErrorJson
            {
                ErrorMessage = "Unknown Error"
            };


            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}
