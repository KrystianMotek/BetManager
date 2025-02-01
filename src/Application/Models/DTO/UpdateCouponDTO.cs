using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class UpdateCouponDTO : IDTO
    {
        public string CouponNumber { get; set; }
        public DictionaryItemDTO Status { get; set; }
        public DictionaryItemDTO CouponType { get; set; }
        public List<UpdateCouponPositionDTO> Positions { get; set; }
        public DateTime ConclusionTime { get; set; }
        public decimal PossibleProfit { get; set; }
        public decimal TotalOdds { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Stake { get; set; }

        public UpdateCouponDTO() {}

        public UpdateCouponDTO(
            string couponNumber,
            DictionaryItemDTO status,
            DictionaryItemDTO couponType,
            List<UpdateCouponPositionDTO> positions,
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
            CouponType = couponType;
            CouponNumber = couponNumber;
            ConclusionTime = conclusionTime;
            PossibleProfit = possibleProfit;
            TotalOdds = totalOdds;
            TaxAmount = taxAmount;
            TaxRate = taxRate;
            Stake = stake;
        }
    }
}