using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class DictionaryItemDTO : IDTO
    {
        public string Scope { get; set; }
        
        public string ItemValue { get; set; }

        public DictionaryItemDTO() {}

        public DictionaryItemDTO(string scope, string itemValue)
        {
            Scope = scope;
            ItemValue = itemValue;
        }
    }
}