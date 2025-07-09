using KubWander.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Конфигурация сервисов
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Настройка статических файлов для SPA
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

// Настройка Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Identity/Account/Login";
    });

builder.Services.AddAuthorization();
builder.Services.AddRazorPages();

var app = builder.Build();

// Конвейер middleware
app.UseStaticFiles(); // Важно: должно быть перед UseSpaStaticFiles
app.UseSpaStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); // Добавлено явное использование маршрутизации
app.UseAuthentication();
app.UseAuthorization();

// Обработка API запросов
app.MapControllers();
app.MapRazorPages();

// Обработка SPA запросов
app.MapWhen(ctx => !ctx.Request.Path.StartsWithSegments("/api") &&
                  !ctx.Request.Path.StartsWithSegments("/swagger") &&
                  !ctx.Request.Path.StartsWithSegments("/identity"),
    appBuilder =>
    {
        appBuilder.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";

            if (app.Environment.IsDevelopment())
            {
                spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
            }
        });
    });

// Fallback для SPA
app.MapFallbackToFile("index.html"); // Добавлено для обработки favicon.ico и других файлов

app.Run();