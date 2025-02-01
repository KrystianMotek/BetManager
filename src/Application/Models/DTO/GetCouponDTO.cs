using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class GetCouponDTO : IDTO
    {
        public Guid Id { get; set; }
        public string CouponNumber { get; set; }
        public DictionaryItemDTO Status { get; set; }
        public DictionaryItemDTO CouponType { get; set; }
        public List<GetCouponPositionDTO> Positions { get; set; }
        public DateTime ConclusionTime { get; set; }
        public decimal PossibleProfit { get; set; }
        public decimal TotalOdds { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Stake { get; set; }

        public GetCouponDTO() {}

        public GetCouponDTO(
            Guid id,
            string couponNumber,
            DictionaryItemDTO status,
            DictionaryItemDTO couponType,
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