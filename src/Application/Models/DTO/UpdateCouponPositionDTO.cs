using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class UpdateCouponPositionDTO : IDTO
    {
        public int PositionNumber { get; set; }
        public DictionaryItemDTO Status { get; set; }
        public DictionaryItemDTO Discipline { get; set; }
        public DictionaryItemDTO BettingType { get; set; }
        public string Description { get; set; }
        public string Choice { get; set; }
        public decimal Odds { get; set; }

        public UpdateCouponPositionDTO() {}

        public UpdateCouponPositionDTO(
            int positionNumber,
            DictionaryItemDTO status, 
            DictionaryItemDTO discipline,
            DictionaryItemDTO bettingType,
            string description,
            string choice,  
            decimal odds
        )
        {
            Discipline = discipline;
            BettingType = bettingType;
            Description = description;
            PositionNumber = positionNumber;
            Status = status;
            Choice = choice;
            Odds = odds;
        }
    }    
}