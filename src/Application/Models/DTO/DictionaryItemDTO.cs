using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class DictionaryItemDTO : IDTO
    {        
        public string ItemValue { get; set; }

        public DictionaryItemDTO() {}

        public DictionaryItemDTO(string itemValue)
        {
            ItemValue = itemValue;
        }
    }
}