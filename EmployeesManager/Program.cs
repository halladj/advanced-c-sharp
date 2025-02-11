using System.Net;
using System.Text;
using System.Text.Json;
using EmployeesManager;
using EmployeesManager.employee;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRepository<Employee>, EmployeeRepository>();

var app = builder.Build();

app.MapGet("/", async ( HttpContext context) => {
    //TODO: add support to arabic langauge via headers.

    context.Response.Headers.Add("X-Custom-Header", "HeaderValue");

    // Check if client wants JSON
    if (context.Request.Headers.Accept.Any(h => h.Contains("application/json")))
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new SpecialResponse{Key="key", Value="value"});
    }
    else
    {
        // Set HTML response
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("""
            <!DOCTYPE html>
            <html>
                <body>
                    <h1>Hello from HTML!</h1>
                </body>
            </html>
        """);
    }
});

var UsersGroup = app.MapGroup("/employee");

UsersGroup.MapGet("/", (IRepository<Employee> repository) => {
    return Results.Ok(repository.GetAll());
});

UsersGroup.MapPost("/", (
    [FromBody]Employee emp,
    IRepository<Employee> repository
    ) => {

    repository.Create(emp);
    return Results.Ok("SUCCESSSSS");
});

UsersGroup.MapGet("/{id:int}", (
    [FromRoute]int id, 
    IRepository<Employee> repository
    ) => {
    return Results.Ok(repository.GetById(id));
});

UsersGroup.MapPut("/{id:int}", (
    [FromRoute]int id, 
    [FromBody] Employee emp,
    IRepository<Employee> repository
    ) => {
    repository.Update(emp);
    return Results.Ok(repository.GetById(id));
});


app.Run();





public class SpecialResponse
{
    public string? Key { get; set; }  
    public string? Value { get; set; } 
    
}