using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class UpdateCouponPositionDTO : IDTO
    {
        public string Status { get; set; }
        public string Discipline { get; set; }
        public string BettingType { get; set; }
        public int PositionNumber { get; set; }
        public string Description { get; set; }
        public string Choice { get; set; } 
        public decimal Odds { get; set; }

        public UpdateCouponPositionDTO() {}

        public UpdateCouponPositionDTO(
            string status, 
            string discipline,
            string bettingType,
            int positionNumber,
            string description,
            string choice,  
            decimal odds
        )
        {
            Status = status;
            Discipline = discipline;
            BettingType = bettingType;
            PositionNumber = positionNumber;
            Description = description;
            Choice = choice;
            Odds = odds;
        }
    }    
}