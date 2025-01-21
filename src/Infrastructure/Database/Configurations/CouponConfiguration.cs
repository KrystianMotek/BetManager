using BetManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BetManager.Infrastructure.Database.Configurations
{
    public static class CouponConfiguration
    {
        public static void ConfigureCoupons(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("Coupons");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.CouponNumber)
                      .IsRequired()
                      .HasMaxLength(40);
                
                entity.Property(e => e.ConclusionTime)
                      .IsRequired();
                
                entity.Property(e => e.Stake)
                      .IsRequired();

                entity.Property(e => e.TotalOdds)
                      .IsRequired();

                entity.Property(e => e.PossibleProfit)
                      .IsRequired();

                entity.Property(e => e.TaxRate)
                      .IsRequired();

                entity.Property(e => e.TaxAmount)
                      .IsRequired();
                
                entity.Property(e => e.CreatedAt)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedAt)
                      .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.CouponNumber)
                      .IsUnique();

                entity.HasMany(e => e.Positions)
                      .WithOne(p => p.Coupon)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.CouponType)
                      .WithMany()
                      .HasForeignKey(e => e.CouponTypeId);

                entity.HasOne(e => e.Status)
                      .WithMany()
                      .HasForeignKey(e => e.StatusId);
            });
        }
    }
}