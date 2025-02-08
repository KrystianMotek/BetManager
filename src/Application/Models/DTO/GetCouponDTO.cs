using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class GetCouponDTO : ICouponDTO<GetCouponPositionDTO>
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string CouponType { get; set; }
        public string CouponNumber { get; set; }
        public DateTime ConclusionTime { get; set; }
        public decimal PossibleProfit { get; set; }
        public decimal TotalOdds { get; set; } 
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Stake { get; set; }

        public List<GetCouponPositionDTO> Positions { get; set; }

        public GetCouponDTO() {}

        public GetCouponDTO(
            Guid id,
            string status,
            string couponType,
            string couponNumber,
            List<GetCouponPositionDTO> positions,
            DateTime conclusionTime,
            decimal possibleProfit,
            decimal totalOdds,
            decimal taxAmount,
            decimal taxRate,
            decimal stake
        )
        {
            Id = id;
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