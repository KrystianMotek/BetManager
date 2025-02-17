namespace BetManager.Domain.Models
{
    public class DictionaryItem : BaseEntity
    {
        public string? Scope { get; set; }
        public string? ItemValue { get; set; }
    }
}