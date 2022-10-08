using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Gestor_Notas.Models;
using Microsoft.Extensions.Configuration;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AC_ScoreContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/login"); //creamos un esquema  de autentificacion por cookies con un esquema default 


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

app.UseAuthentication(); // se agrega la opcion de autentificacion 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
