using Microsoft.EntityFrameworkCore;
using WebApplication33333;
using WebApplication33333.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Dz2Context>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=dz2;Username=postgres;Password=123;"));

// Добавляем контекст базы данных


builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews(); // Убедитесь, что это не закомментировано
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
