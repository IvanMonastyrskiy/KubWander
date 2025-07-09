using KubWander.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ������������ ��������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� ����������� ������ ��� SPA
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

// ��������� Identity
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

// �������� middleware
app.UseStaticFiles(); // �����: ������ ���� ����� UseSpaStaticFiles
app.UseSpaStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); // ��������� ����� ������������� �������������
app.UseAuthentication();
app.UseAuthorization();

// ��������� API ��������
app.MapControllers();
app.MapRazorPages();

// ��������� SPA ��������
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

// Fallback ��� SPA
app.MapFallbackToFile("index.html"); // ��������� ��� ��������� favicon.ico � ������ ������

app.Run();