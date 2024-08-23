using Mango.Services.ShppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShppingCartAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

        
        
    }
}
