namespace BetManager.Domain.Models
{
    public class CouponPosition : BaseEntity
    {
        public Guid CouponId { get; set; }
        public Guid StatusId { get; set; } 
        public Guid DisciplineId { get; set; }
        public Guid BettingTypeId { get; set; }
        public string? Description { get; set; }
        public int PositionNumber { get; set; }
        public string? Choice { get; set; }
        public decimal Odds { get; set; }

        public Coupon? Coupon { get; set; }
        public DictionaryItem? Status { get; set; }
        public DictionaryItem? Discipline { get; set; }
        public DictionaryItem? BettingType { get; set; } 
    }
}