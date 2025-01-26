using BetManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BetManager.Infrastructure.Database.Configurations
{
    public static class CouponPositionConfiguration
    {
        public static void ConfigureCouponPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CouponPosition>(entity =>
            {
                entity.ToTable("CouponPositions");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                      .IsRequired()
                      .HasMaxLength(120);

                entity.Property(e => e.Choice)
                      .IsRequired()
                      .HasMaxLength(40);

                entity.Property(e => e.Odds)
                      .IsRequired()
                      .HasPrecision(10, 2);

                entity.Property(e => e.CreatedAt)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedAt)
                      .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Coupon)
                      .WithMany(c => c.Positions)
                      .HasForeignKey(e => e.CouponId)
                      .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(e => e.Status)
                      .WithMany()
                      .HasForeignKey(e => e.StatusId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Discipline)
                      .WithMany()
                      .HasForeignKey(e => e.DisciplineId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.BettingType)
                      .WithMany()
                      .HasForeignKey(e => e.BettingTypeId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}