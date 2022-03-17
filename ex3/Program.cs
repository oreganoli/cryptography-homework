using JWT;
using Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services;
using JWT.Algorithms;
using JWT.Serializers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSingleton(typeof(IUserRepository), typeof(InmemUserRepository));

var decoder = new JwtDecoder(new JsonNetSerializer(), new JwtBase64UrlEncoder());
builder.Services.AddSingleton(typeof(IJwtDecoder), decoder);

var encoder = new JwtEncoder(new HMACSHA256Algorithm(), new JsonNetSerializer(), new JwtBase64UrlEncoder());
builder.Services.AddSingleton(typeof(IJwtEncoder), encoder);

var validator = new JwtValidator(new JsonNetSerializer(), new UtcDateTimeProvider());
builder.Services.AddSingleton(typeof(IJwtValidator), validator);

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
