using JWT;
using Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services;
using JWT.Algorithms;
using JWT.Serializers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSingleton(typeof(IUserRepository), typeof(InmemUserRepository));

builder.Services.AddSingleton(typeof(IAuthenticationSvc), typeof(AuthenticationSvc));

var app = builder.Build();
app.UseExceptionHandler(appError => appError.Run(async context =>
{
    var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
    if (exception is AppException ex)
    {
        context.Response.StatusCode = ex.Code;
    }
    var response = new { error = exception?.Message ?? "No error message could be retrieved." };
    await context.Response.WriteAsJsonAsync(response);
}));
app.MapControllers();
app.Run();
