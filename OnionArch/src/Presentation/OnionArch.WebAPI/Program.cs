using OnionArch.Persistance;
using Scalar.AspNetCore;
using OnionArch.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();
app.UseAuthorization();
app.MapControllers();
app.Run();

