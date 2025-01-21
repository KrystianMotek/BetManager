using BetManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BetManager.Infrastructure.Database.Configurations;

namespace BetManager.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() {}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureCoupons();
            modelBuilder.ConfigureCouponPositions();
            modelBuilder.ConfigureDictionaryItems();
        }

        public required DbSet<Coupon> Coupons { get; set; }
        public required DbSet<CouponPosition> CouponPositions { get; set; }
        public required DbSet<DictionaryItem> DictionaryItems { get; set; }
    }
}