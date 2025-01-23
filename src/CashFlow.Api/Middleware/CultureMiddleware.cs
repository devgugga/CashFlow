﻿using System.Globalization;

namespace CashFlow.Api.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
        var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
        var cultureInfo = new CultureInfo("pt-br");

        if (!string.IsNullOrWhiteSpace(requestCulture) && supportedLanguages.Exists(l => l.Name.Equals(requestCulture)))
            cultureInfo = new CultureInfo(requestCulture);

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}