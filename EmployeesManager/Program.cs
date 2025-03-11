using System.ComponentModel.DataAnnotations;
using EmployeesManager;
using EmployeesManager.Users;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRepository<Users>, UserRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();


if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();