using Business.Services.Abstracts;
using Business.Services.Concretes;
using Core.Model;
using Core.RepositoryAbstracts;
using Data.DAL;
using Data.RepositoryConretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{ opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")); }

);
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireLowercase=true;
    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = 8;

    opt.User.RequireUniqueEmail=false;
}


).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IDoctorServices,DoctorServices>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
