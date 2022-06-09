using FridgeManager.ASP.Extentions;
using FridgeManager.Domain.Models.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseUrls("http://localhost:5012");

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.ConfigureHost(builder.Configuration);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=StartPage}/");

app.Run();