using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

 

 

var app = builder.Build();







app.MapGet("/login", () =>
{
    return "Hi there";

});

 

app.Run();


 