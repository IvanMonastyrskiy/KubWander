//using KubWander.Models;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddSpaStaticFiles(configuration =>
//{
//    configuration.RootPath = "ClientApp/dist";
//});

//builder.Services.AddIdentity<User, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Identity/Account/Login";
//    });

//builder.Services.AddAuthorization();
//builder.Services.AddRazorPages();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});

//var app = builder.Build();

//app.UseStaticFiles();
//app.UseSpaStaticFiles();
//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Append("Content-Type", "text/html; charset=utf-8");
//    await next();
//});
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseRouting(); 
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();
//app.MapRazorPages();

//app.MapWhen(ctx => !ctx.Request.Path.StartsWithSegments("/api") &&
//                  !ctx.Request.Path.StartsWithSegments("/swagger") &&
//                  !ctx.Request.Path.StartsWithSegments("/identity"),
//    appBuilder =>
//    {
//        appBuilder.UseSpa(spa =>
//        {
//            spa.Options.SourcePath = "ClientApp";

//            if (app.Environment.IsDevelopment())
//            {
//                spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
//            }
//        });
//    });
//app.UseCors("AllowAll");
//app.MapFallbackToFile("index.html");

//app.Run();


using KubWander.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSpaStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll"); // Переместите CORS перед UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

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

app.MapFallbackToFile("index.html");

app.Run();