var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseUrls("http://localhost:5012");

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=StartPage}/");

app.Run();