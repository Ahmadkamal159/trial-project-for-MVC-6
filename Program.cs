using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using trial_project_for_MVC_Core.EntityDB;
using trial_project_for_MVC_Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//add DB services and take connectionstring from json file directly
//must put it here before building the app
builder.Services.AddDbContext<UniversityEntity>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{   
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 8;
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<UniversityEntity>().AddDefaultTokenProviders();

var app = builder.Build();
//add DB services and take connectionstring from json file directly
//builder.Services.AddDbContext<UniversityEntity>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
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
