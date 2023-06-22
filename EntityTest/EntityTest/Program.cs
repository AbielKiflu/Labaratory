using DbAcess.DataAcess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DbAcess.Models;
//using DbAcess.DataAcess;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDataContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/test", () =>
{
    var hasher=new PasswordHasher<User>();
    var hashed = hasher.HashPassword(null, "Abi");
    return hashed + " => " + hasher.VerifyHashedPassword(null,hashed,"Abi");

});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
