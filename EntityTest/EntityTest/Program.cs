using DbAcess.DataAcess;
using Microsoft.EntityFrameworkCore;
using DbAcess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
//using DbAcess.DataAcess;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddControllersWithViews();

 

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "UserCookie";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Account";
    options.LogoutPath = "/Account/Logout";

});

builder.Services.AddAntiforgery(options =>
{
    options.Cookie.Name = "AntiforgeryCookie";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.HeaderName = "X-CSRF-TOKEN";

});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("", policy => policy.RequireClaim("Test"));
});


builder.Services.AddDbContext<MyDataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
    
});

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

 
 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");



app.Run();
