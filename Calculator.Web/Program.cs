using Calculator.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Calculator.Data.Models;
using Calculator.Common.Models;
using Calculator.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Connection string'i al
var connectionString = builder.Configuration.GetConnectionString("Default");

// DbContext'i kaydet
builder.Services.AddDbContext<CalculatorDbContext>(options =>
options.UseSqlServer(connectionString,
        a => a.MigrationsAssembly("Calculator.Data")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<CalculatorDbContext>()
    .AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseMiddleware<UsageCounterMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.Run();
