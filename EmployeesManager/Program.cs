using System.ComponentModel.DataAnnotations;
using EmployeesManager;
using EmployeesManager.Users;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRepository<Users>, UserRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();

var app = builder.Build();


if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

var usersGroup = app.MapGroup("/users");

usersGroup.MapGet("/", (
    IRepository<Users> r
) => {
    return Results.Ok(r.GetAll());    
});

usersGroup.MapPost("/", (
    [FromBody]Users user,
    IRepository<Users> r
    ) => {

    var validationProblems = new List<ValidationResult>();
    var isValid = Validator.TryValidateObject(
        user,
        new ValidationContext(user),
        validationProblems,
        true
    );

    if (!isValid)
    {
        return Results.BadRequest(validationProblems);
    }

    r.Create(user);
    return Results.Ok("success");    
});

usersGroup.MapGet("/{id}", (
    [FromRoute]int id,
    IRepository<Users> r
) => {
    var user = r.GetById(id);
    Console.WriteLine(r.GetById(id));
    if (user != null){
        return Results.Ok(user);
    }
    return Results.NotFound("User Not Found");
});


usersGroup.MapPut("/users/{id}", (
    [FromRoute]int id,
    [FromBody] Users user,
    IRepository<Users> r
    ) => {
    r.Update(user);
    return Results.Ok("success");    
});

usersGroup.MapDelete("/users/{id}", (
    [FromRoute]int id,
    [FromBody] Users user,
    IRepository<Users> r
    ) => {
    r.Delete(user);
    return Results.Ok("success");    
});

app.Run();





