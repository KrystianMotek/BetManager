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

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(p => p.PositionNumber)
                      .IsRequired()
                      .UseIdentityColumn(1, 1);

                entity.Property(p => p.Description)
                      .IsRequired()
                      .HasMaxLength(120);

                entity.Property(p => p.Choice)
                      .IsRequired()
                      .HasMaxLength(40);

                entity.Property(p => p.Odds)
                      .IsRequired()
                      .HasPrecision(10, 2);

                entity.Property(p => p.CreatedAt)
                      .ValueGeneratedOnAdd();

                entity.Property(p => p.ModifiedAt)
                      .ValueGeneratedOnAdd();

                entity.HasOne(p => p.Coupon)
                      .WithMany(c => c.Positions)
                      .HasForeignKey(p => p.CouponId)
                      .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(p => p.Status)
                      .WithMany()
                      .HasForeignKey(p => p.StatusId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.Discipline)
                      .WithMany()
                      .HasForeignKey(p => p.DisciplineId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.BettingType)
                      .WithMany()
                      .HasForeignKey(p => p.BettingTypeId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}