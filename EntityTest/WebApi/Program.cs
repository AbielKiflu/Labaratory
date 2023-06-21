using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.TryAddScoped<RandomGen>();

var app = builder.Build();

 

 

 

app.MapGet("/login", (HttpContext ctx, RandomGen rnd) =>
{
    ctx.Response.Headers["set-cookie"] = "auth=user:abiel;SameSite=None; Secure;";
  
    return rnd.randomVal().ToString();
});

 

app.Run();


public class RandomGen
{

 
    public int randomVal()
    {
        Random rnd = new Random();
        return rnd.Next();
    }
}