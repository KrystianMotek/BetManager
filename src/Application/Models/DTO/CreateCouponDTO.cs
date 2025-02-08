using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class CreateCouponDTO : ICouponDTO<CreateCouponPositionDTO>
    {
        public string Status { get; set; }
        public string CouponType { get; set; }
        public string CouponNumber { get; set; }
        public DateTime ConclusionTime { get; set; }
        public decimal PossibleProfit { get; set; }
        public decimal TotalOdds { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Stake { get; set; }

        public List<CreateCouponPositionDTO> Positions { get; set; }

        public CreateCouponDTO() {}
    }
}