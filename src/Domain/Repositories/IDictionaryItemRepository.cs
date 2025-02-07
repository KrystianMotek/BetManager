using BetManager.Domain.Models;

namespace BetManager.Domain.Repositories
{
    public interface IDictionaryItemRepository
    {
        public Task<DictionaryItem?> GetByIdAsync(Guid id);
        public Task<List<string>> GetUniqueScopesAsync();
        public Task<DictionaryItem?> GetByScopeAndItemValueAsync(string scope, string itemValue);
        public Task<DictionaryItem> CreateAsync(DictionaryItem dictionaryItem);
        public Task<DictionaryItem> UpdateAsync(DictionaryItem dictionaryItem);
        public Task<DictionaryItem> DeleteAsync(DictionaryItem dictionaryItem);
    }
}