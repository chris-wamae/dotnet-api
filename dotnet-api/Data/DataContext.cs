using dotnet_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Data
{
    public class DataContext : IdentityDbContext<ApiUser>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Game> Games { get; set; }

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Studio> Studios { get; set; }

        public DbSet<Pro_player> Pros { get; set; }

        public DbSet<GamePlatform> GamePlatforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GamePlatform>()
                .HasKey(pc => new { pc.GameId, pc.PlatformId });

            modelBuilder.Entity<GamePlatform>()
                .HasOne(p => p.Game)
                .WithMany(pc => pc.GamePlatforms)
                .HasForeignKey(c => c.GameId);

            modelBuilder.Entity<GamePlatform>()
                .HasOne(p => p.Platform)
                .WithMany(pc => pc.GamePlatforms)
                .HasForeignKey(c => c.PlatformId);



        }




    }
}
