using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios MVC
builder.Services.AddControllersWithViews();

// Configurar HttpClient para consumir la API
builder.Services.AddHttpClient("RestaurantesAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7165/api/restaurantes");
});

var app = builder.Build();

// Configurar pipeline de middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Restaurantes}/{action=Index}/{id?}");

app.Run();
