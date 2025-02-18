namespace RestaurantesAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using RestaurantesAPI.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Restaurante> Restaurantes { get; set; }
    }
}

