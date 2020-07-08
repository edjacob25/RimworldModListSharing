using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models.Database
{
    public class MyContext : DbContext
    {
        public DbSet<ModList> ModLists { get; set; }
        public DbSet<ModList> Mods { get; set; }

        public MyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModList>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Mod>()
                .HasKey(m => new { m.Id, m.Name });

            modelBuilder.Entity<Mod>()
                .HasAlternateKey(m => m.Id);

            modelBuilder.Entity<ModListMod>()
                .HasKey(m => new { m.ModListId, m.ModId });

            modelBuilder.Entity<ModListMod>()
                .HasOne<ModList>(m => m.ModList)
                .WithMany(m => m.Mods)
                .HasForeignKey(m => m.ModListId);

            modelBuilder.Entity<ModListMod>()
                .HasOne<Mod>(m => m.Mod)
                .WithMany(m => m.ModLists)
                .HasForeignKey(m => new { m.ModId, m.ModName });
        }
    }
}