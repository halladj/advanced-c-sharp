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

    if (request.Headers.AcceptLanguage.Equals("ar"))
    {
        context.Response.Headers.Append("Content-Type", "text/html; charset=utf-8");
        await context.Response.WriteAsync("<h1>مثلا مرحبا بيك يا استاذ عندنا</h1>");
        return Results.Ok();
    } else if (request.Headers.AcceptLanguage.Equals("en"))
    {
        context.Response.Headers.Append("Content-Type", "text/html; charset=utf-8");
        await context.Response.WriteAsync("<h1>Welcome abourd Houssem</h1>");
        return Results.Ok();
    }else 
    {
        return Results.BadRequest("Unrecognized language");
    }
});

app.Run();




public class Response{
    public string? key {get;set;}

    public string?value {get; set;}
}



