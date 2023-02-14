using BooksWebApp.Helpers;
using BooksWebApp.Services.AccountService;
using BooksWebApp.Services.AuthorService;
using BooksWebApp.Services.BookService;
using BooksWebApp.Services.PublisherService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddHttpClient();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "DefaultScheme";
})
    .AddCookie("DefaultScheme", options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
