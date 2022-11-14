using lec5.Data;
using lec5.Migrations;
using lec5.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication("cookie").AddCookie("cookie", a =>
{
    a.LogoutPath = "/account/Login";
    a.AccessDeniedPath = "/account/AccessDenied";
    a.LogoutPath = "/account/logout";
});

builder.Services.AddDbContext<DataBase>(a=> { a.UseSqlServer(builder.Configuration.GetConnectionString("Database")); } );

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
