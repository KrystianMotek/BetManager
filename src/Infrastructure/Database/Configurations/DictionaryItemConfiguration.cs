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

                entity.HasKey(d => d.Id);

                entity.Property(d => d.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(d => d.Scope)
                      .IsRequired()
                      .HasMaxLength(60);

                entity.Property(d => d.ItemValue)
                      .IsRequired()
                      .HasMaxLength(60);
            });
        }
    }
}