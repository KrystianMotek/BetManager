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

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(c => c.CouponNumber)
                      .IsRequired()
                      .HasMaxLength(40);
                
                entity.Property(c => c.ConclusionTime)
                      .IsRequired();
                
                entity.Property(c => c.Stake)
                      .IsRequired()
                      .HasPrecision(10, 2);

                entity.Property(c => c.TotalOdds)
                      .IsRequired()
                      .HasPrecision(10, 2);

                entity.Property(c => c.PossibleProfit)
                      .IsRequired()
                      .HasPrecision(10, 2);

                entity.Property(c => c.TaxRate)
                      .IsRequired()
                      .HasPrecision(10, 2);

                entity.Property(c => c.TaxAmount)
                      .IsRequired()
                      .HasPrecision(10, 2);
                
                entity.Property(c => c.CreatedAt)
                      .ValueGeneratedOnAdd();

                entity.Property(c => c.ModifiedAt)
                      .ValueGeneratedOnAdd();

                entity.HasIndex(c => c.CouponNumber)
                      .IsUnique();

                entity.HasMany(c => c.Positions)
                      .WithOne(p => p.Coupon)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.CouponType)
                      .WithMany()
                      .HasForeignKey(c => c.CouponTypeId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.Status)
                      .WithMany()
                      .HasForeignKey(c => c.StatusId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}