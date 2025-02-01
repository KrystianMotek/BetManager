using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class CreateDictionaryItemDTO : IDTO
    {        
        public string ItemValue { get; set; }

        public CreateDictionaryItemDTO() {}

        public CreateDictionaryItemDTO(string scope, string itemValue)
        {
            Scope = scope;
            ItemValue = itemValue;
        }
    }
}