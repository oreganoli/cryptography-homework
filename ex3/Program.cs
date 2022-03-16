using Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton(typeof(IUserRepository), typeof(InmemUserRepository));
var app = builder.Build();
app.UseExceptionHandler(appError => appError.Run(async context =>
{
    var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
    if (exception is UserExistsException)
    {
        context.Response.StatusCode = StatusCodes.Status409Conflict;
    }
    var response = new { error = exception?.Message ?? "No error message could be retrieved." };
    await context.Response.WriteAsJsonAsync(response);
}));
app.MapControllers();
app.Run();
