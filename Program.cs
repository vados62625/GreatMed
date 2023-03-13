using MotoHelp.Data;
using MotoHelp.Data.Interfaces;
using MotoHelp.Data.Repository;
using MotoHelp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MotoHelp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddDebug();
builder.Logging.AddConsole();

builder.Configuration.Bind("MHConfig", new MHConfig());

builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();
builder.Services.AddDbContext<DBContent>(options => options.UseSqlServer(MHConfig.ConnectionString));
builder.Services.AddTransient<IGetServices, MHServiceRepository>();
builder.Services.AddTransient<IGetDetails, MHDetailRepositiory>();
builder.Services.AddTransient<IGetDetailCategories, MHCategoryRepositiory>();
builder.Services.AddTransient<ICallsRepository, MHCallsRepository>();
builder.Services.AddTransient<IImagesRepository, ImagesRepository>();
builder.Services.AddTransient<ITextFieldsRepository, TextFieldsRepository>();
builder.Services.AddTransient<DataManager>();
//builder.Services.AddSwaggerGen();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//                .AddCookie(options =>
//                {
//                    options.LoginPath = new PathString("/personal/login");
//                });

//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Default Password settings.
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequiredLength = 6;
//    options.Password.RequiredUniqueChars = 1;
//});
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<DBContent>().AddDefaultTokenProviders();

//настраиваем authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "MotoHelpAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/personal/login";
    options.AccessDeniedPath = "/personal/accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan= TimeSpan.FromMinutes(30);
});

//настраиваем политику авторизации для Admin area
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("admin", "{area:exists}/{controller=TextFields}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "catalog",
                pattern: "catalog/{category}/{id:int?}",
                defaults: new { controller = "Details", action = "Index" });
});

using (var scope = app.Services.CreateScope())
{
    DBContent content = scope.ServiceProvider.GetRequiredService<DBContent>();
    DBObjects.Inital(content);
    content.Database.Migrate();
}

app.Run();