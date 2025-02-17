namespace BetManager.Domain.Models
{
    public class Coupon : BaseEntity
    {
        public Guid StatusId { get; set; }
        public Guid CouponTypeId { get; set; }
        public string? CouponNumber { get; set; }
        public DateTime ConclusionTime { get; set; }
        public decimal PossibleProfit { get; set; }
        public decimal TotalOdds { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Stake { get; set; }

        public List<CouponPosition>? Positions { get; set; }

        public DictionaryItem? CouponType { get; set; }
        public DictionaryItem? Status { get; set; }
    }
}