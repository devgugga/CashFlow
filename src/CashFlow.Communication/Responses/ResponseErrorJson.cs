﻿namespace CashFlow.Communication.responses;

public class ResponseErrorJson
{
    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = [errorMessage];
    }

    public ResponseErrorJson(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }

    public List<string> ErrorMessages { get; set; }
}