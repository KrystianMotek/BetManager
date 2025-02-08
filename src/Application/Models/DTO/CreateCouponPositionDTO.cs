using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class CreateCouponPositionDTO : ICouponPositionDTO
    {
        public string Status { get; set; }
        public string Discipline { get; set; }
        public string BettingType { get; set; }
        public string Description { get; set; }
        public string Choice { get; set; } 
        public decimal Odds { get; set; }
        
        public CreateCouponPositionDTO() {}

        public CreateCouponPositionDTO(
            string status, 
            string discipline,
            string bettingType,
            string description,
            string choice,  
            decimal odds
        )
        {
            Discipline = discipline;
            BettingType = bettingType;
            Description = description;
            Status = status;
            Choice = choice;
            Odds = odds;
        }
    }
}