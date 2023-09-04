using FrontToBack;
using FrontToBack.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.Register(config);

var app = builder.Build();

app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

app.UseStaticFiles();

app.Run();