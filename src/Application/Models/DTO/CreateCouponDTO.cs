using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class CreateCouponDTO : IDTO
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

        public CreateCouponDTO(
            string status,
            string couponType,
            string couponNumber,
            List<CreateCouponPositionDTO> positions,
            DateTime conclusionTime,
            decimal possibleProfit,
            decimal totalOdds,
            decimal taxAmount,
            decimal taxRate,
            decimal stake
        )
        {
            Status = status;
            Positions = positions;
            TotalOdds = totalOdds;
            CouponType = couponType;
            CouponNumber = couponNumber;
            ConclusionTime = conclusionTime;
            PossibleProfit = possibleProfit;
            TaxAmount = taxAmount;
            TaxRate = taxRate;
            Stake = stake;
        }
    }
}