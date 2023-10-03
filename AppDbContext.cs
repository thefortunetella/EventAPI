using Microsoft.EntityFrameworkCore;
using EventAPI.Models;

namespace EventApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de entidades e relações 
        }
    }
}

