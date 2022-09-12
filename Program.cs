using GreatMed.Data;
using GreatMed.Data.Interfaces;
using GreatMed.Data.Repository;
using GreatMed.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Bind("GMConfig", new GMConfig());

builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();
builder.Services.AddDbContext<DBContent>(options => options.UseSqlServer(GMConfig.ConnectionString));
builder.Services.AddTransient<IGetServices, GMServiceRepository>();

var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

using (var scope = app.Services.CreateScope())
{
    DBContent content = scope.ServiceProvider.GetRequiredService<DBContent>();
    DBObjects.Inital(content);
}

//app.MapGet("/", () => "Hello World!");

app.Run();
