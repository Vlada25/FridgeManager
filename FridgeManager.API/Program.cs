using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FridgeManager.Domain;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using Microsoft.IdentityModel.Tokens;
using FridgeManager.Domain.Models.Authorization;
using FridgeManager.API.Extensions;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseUrls("http://localhost:5001");

builder.Services.ConfigureDbManagers();

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

//.AddXmlDataContractSerializerFormatters();

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddHttpContextAccessor();

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

// automapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper autoMapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(autoMapper);

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

// logging
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    ILoggerManager logger = services.GetService<ILoggerManager>();
    app.ConfigureExceptionHandler(logger);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseIpRateLimiting();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();