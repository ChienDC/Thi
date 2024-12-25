using Microsoft.EntityFrameworkCore;
using Thi.Models;

namespace Thi
{
    public class ThiDbContext : DbContext
    {
        public ThiDbContext(DbContextOptions<ThiDbContext>options) : base(options)
        {

        }
        
        public DbSet<Thi.Models.ComicBooks> ComicBooks { get; set; } = default!;

        public DbSet<Customers> Customers { get; set; } = default!;
        public DbSet<Thi.Models.Rentals> Rentals { get; set; } = default!;
        public DbSet<RetalDetails> RetalDetails { get; set; } = default!;


    }
}
