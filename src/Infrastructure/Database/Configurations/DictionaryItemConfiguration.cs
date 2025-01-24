using BetManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BetManager.Infrastructure.Database.Configurations
{
    public static class DictionaryItemConfiguration
    {
        public static void ConfigureDictionaryItems(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DictionaryItem>(entity => 
            {
                entity.ToTable("DictionaryItems");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Scope)
                      .IsRequired()
                      .HasMaxLength(60);

                entity.Property(e => e.ItemValue)
                      .IsRequired()
                      .HasMaxLength(60);
            });
        }
    }
}