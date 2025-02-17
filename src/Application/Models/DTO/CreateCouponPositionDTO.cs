using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class CreateCouponPositionDTO : ICouponPositionDTO
    {
        public string? Status { get; set; }
        public string? Discipline { get; set; }
        public string? BettingType { get; set; }
        public string? Description { get; set; }
        public string? Choice { get; set; } 
        public decimal Odds { get; set; }
        
        public CreateCouponPositionDTO() {}
    }
}