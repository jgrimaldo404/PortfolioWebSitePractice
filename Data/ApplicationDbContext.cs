using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Contructor that acceepts a dbcontext  
        // To configure a entity framework data context use 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplicationMVC.Models.Joke> Joke { get; set; }
    }
}