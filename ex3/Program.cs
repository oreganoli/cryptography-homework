using Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton(typeof(IUserRepository), typeof(InmemUserRepository));
var app = builder.Build();
app.MapControllers();
app.Run();
