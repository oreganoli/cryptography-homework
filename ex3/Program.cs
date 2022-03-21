using Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSingleton(typeof(IUserRepository), typeof(InmemUserRepository));
builder.Services.AddSingleton(typeof(IAuthenticationSvc), typeof(AuthenticationSvc));
builder.Services.AddSingleton(typeof(Ex1Hasher));
builder.Services.AddSingleton(typeof(Ex2Hasher));
builder.Services.AddSingleton(typeof(IHasherProvider), typeof(HasherProvider));
builder.Services.AddSingleton(typeof(IUserLogic), typeof(UserLogic));

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
