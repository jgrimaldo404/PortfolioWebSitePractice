using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//gets connectionstring and name you want to get 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Helps inject eneity framework data content 
// Uses dependency injection 
//allows us to define options too 
// Login,registration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
// Tells what kind of db you will be connnecting to 
//  useSqlServer to tell it is a Microsoft DB 
//connectionString tells entity framework  how to connect to the tagrte database  
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
// In order to see custom error page you will need to disable
// Debug tab in project build properties 
// Look for ASPNETCORE_ENVIRONMENT which enables developer mode
// Set it to another value or remove it then it will not run in developer mode 
// Will then how custom error page 
// Can set it up back by assigning it to code (from production)
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // listens for any exceptiosna dn logs error and redirects to a friendly error page
    // will not show the defualt page shown by ASP.NET that can contain code and is s secruity risk 
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirects us to HTTPS  if we were using HTTP
app.UseHttpsRedirection();
//Things like static HTML file 
app.UseStaticFiles();

app.UseRouting();

//Adds authentication
app.UseAuthentication();
app.UseAuthorization();

//ENDPOINTS
// 2 MAPS
//FIRST: MapControllerRoute
//Could add more than 1 route if we wanted 
//These are all default values
//No route will means it goes to this configured route

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//SECONDROUTE
// Looks for Razor ages and map those routes
// Be carefule of Rzor page matching default route
// Having same pages as other pages
app.MapRazorPages();

app.Run();
