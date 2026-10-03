using GestorLigaFutbol.Consumer;
using GestorLigaFutbol.Models;
using Microsoft.EntityFrameworkCore;


// endpoints
CRUD<Equipo>.Endpoint = "https://localhost:7230/api/Equipos";
CRUD<Estadio>.Endpoint = "https://localhost:7230/api/Estadios";
CRUD<Jugador>.Endpoint = "https://localhost:7230/api/Jugadores";
CRUD<Partido>.Endpoint = "https://localhost:7230/api/Partidos";
CRUD<Liga>.Endpoint = "https://localhost:7230/api/Ligas";
CRUD<Gol>.Endpoint = "https://localhost:7230/api/Goles";


var builder = WebApplication.CreateBuilder(args); // NO QUITAR





// Add services to the container.
builder.Services.AddControllersWithViews();

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
