using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Html;

var builder = WebApplication.CreateBuilder(args);

var  app = builder.Build();


// 
app.MapGet("/", async (HttpRequest request,HttpContext context)=>{
    //to do home: add support to  arabic langauge via headers.
    if(request.Headers.Accept.Equals("application/json")){
        //mobile app for ex:
        Console.WriteLine("Client requested JSON");
        return Results.Ok(new Response{key = "name",value = "houssem"});
    }

    //browser app (website):
    context.Response.Headers.Append("content-type", "text/html");
    await context.Response.WriteAsync("<h1>this is a title<h1/>");
    return Results.Ok();
    
});

app.Run();




public class Response{
    public string? key {get;set;}

    public string?value {get; set;}
}



