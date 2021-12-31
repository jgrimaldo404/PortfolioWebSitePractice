using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//gets connectionstring and name you want to get 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Helps inject eneity framework data content 
//allows us to define options too 
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
// In order to see custom erro page you will need to disable
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
