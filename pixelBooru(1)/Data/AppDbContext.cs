using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pixelBooru_1_.Models;

namespace pixelBooru_1_.Data
{
    public class AppDbContext : IdentityDbContext<users>
    {
        public DbSet<Artwork> Artworks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

      
        }
        public List<string> GetAllUsernames()
        {
            return [.. Users.Select(u => u.UserName)];
        }
    }
}
