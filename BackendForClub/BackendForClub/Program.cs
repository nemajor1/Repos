using Microsoft.EntityFrameworkCore;
using BackendForClub.Data;
using BackendForClub.Controllers.Authorization;
using BackendForClub.Controllers.Registration;
using BackendForClub.Controllers.Balance;
using BackendForClub.Controllers.UsersModel;
using BackendForClub.Controllers.Bar;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
    c.RoutePrefix = "swagger";
});

app.Authorization();
app.Registration();
app.Balance();
app.Users();
app.Bar();

app.Run();