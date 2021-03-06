using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WebApplication.Models.Database
{
    public class MyContext : DbContext
    {
        static MyContext() => NpgsqlConnection.GlobalTypeMapper.MapEnum<Expansions>();
        public DbSet<ModList> ModLists { get; set; }
        public DbSet<Mod> Mods { get; set; }

        public MyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Expansions>();

            modelBuilder.Entity<ModList>().ToTable("ModList");

            modelBuilder.Entity<ModList>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Mod>().ToTable("Mod");

            modelBuilder.Entity<Mod>()
                .HasKey(m => new { m.Id, m.Name });

            modelBuilder.Entity<Mod>()
                .HasIndex(m => m.Id);

            modelBuilder.Entity<ModListMod>().ToTable("ModListMod");

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