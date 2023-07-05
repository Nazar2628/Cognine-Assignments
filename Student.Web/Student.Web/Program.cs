using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;
using SchoolProject.Services;
using SchoolProject.Utilities;
using Student.Web.Data;
using StudentProject.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StudentWebContextConnection") ?? throw new InvalidOperationException("Connection string 'StudentWebContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
//builder.Services.AddScoped<DbContext,ApplicationDbContext>();

builder.Services.AddScoped<IDbIntializer, DbIntializer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IStudentService, StudentService>();

// Add services to the container.
builder.Services.AddControllersWithViews();


 var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var DbIntializer = scope.ServiceProvider.GetRequiredService<IDbIntializer>();
    DbIntializer.Intialize();
}

//using(Func<IServiceScope> scope = app.Services.CreateScope)
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//}
//using (var scope = app.Services.CreateScope())
//{
//    var StudentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
//    StudentService.GetAllStudents();
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{          
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


