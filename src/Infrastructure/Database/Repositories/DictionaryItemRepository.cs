using BetManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using BetManager.Domain.Repositories;

namespace BetManager.Infrastructure.Database.Repositories
{
    public class DictionaryItemRepository(ApplicationDbContext context) : IDictionaryItemRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<DictionaryItem?> GetByIdAsync(Guid id)
            => await _context.DictionaryItems.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<DictionaryItem?> GetByScopeAndItemValueAsync(string scope, string itemValue)
            => await _context.DictionaryItems.FirstOrDefaultAsync(e => e.Scope == scope && e.ItemValue == itemValue);
        
        public async Task<DictionaryItem> CreateAsync(DictionaryItem dictionaryItem)
        {
            await _context.DictionaryItems.AddAsync(dictionaryItem);
            await _context.SaveChangesAsync();
            return dictionaryItem;
        }

        public async Task<DictionaryItem> UpdateAsync(DictionaryItem dictionaryItem)
        {
            _context.DictionaryItems.Update(dictionaryItem);
            await _context.SaveChangesAsync();
            return dictionaryItem;
        }

        public async Task<DictionaryItem> DeleteAsync(DictionaryItem dictionaryItem)
        {
            _context.DictionaryItems.Remove(dictionaryItem);
            await _context.SaveChangesAsync();
            return dictionaryItem;
        }
    }
}