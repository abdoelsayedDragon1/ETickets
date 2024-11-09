using ETickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ETickets.ViewModel;

namespace ETickets.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<PurchasedProduct> purchasedProducts { get; set; }
       
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
        var Connection = builder.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(Connection);
    }
 
    }
}
