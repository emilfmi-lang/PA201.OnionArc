using OnionArch.Persistance;
using Scalar.AspNetCore;
using OnionArch.Application;
using OnionArch.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapOpenApi();
app.MapScalarApiReference();
app.UseAuthorization();
app.MapControllers();
app.Run();

