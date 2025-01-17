using BetManager.Domain.Models;
using Microsofr.EntityFrameworkCore;

namespace BetManager.Infrastructure.Database.Configurations
{
    public class CouponPositionConfiguration
    {
        public static void ConfigureCouponPosition(this ModelBuilder modelBuilder)
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
                      .IsRequired();

                entity.Property(e => e.CreatedAt)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedAt)
                      .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Coupon)
                      .WithMany()
                      .HasForeignKey(e => e.CouponId);
                
                entity.HasOne(e => e.Status)
                      .WithMany()
                      .HasForeignKey(e => e.StatusId);

                entity.HasOne(e => e.Discipline)
                      .WithMany()
                      .HasForeignKey(e => e.DisciplineId);

                entity.HasOne(e => e.BettingType)
                      .WithMany()
                      .HasForeignKey(e => e.BettingTypeId);
            });
        }
    }
}