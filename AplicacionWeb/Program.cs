using Microsoft.EntityFrameworkCore;
using GestorPublicidad.DAL.DataContext;
using GestorPublicidad.DAL.Repositories;
using GestorPublicidad.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<S3kGestorPublicidadContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));

});

builder.Services.AddScoped<IGenericRepository<ImagenVideo>, ImagenVideoRepository>();

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
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Screen}/{action=Index}/{id?}");

app.Run();
