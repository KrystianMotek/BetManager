using BetManager.Domain.Models;

namespace BetManager.Application.Models.DTO
{
    public class GetCouponPositionDTO : ICouponPositionDTO
    {
        public Guid Id { get; set; }
        public string? Status { get; set; }
        public string? Discipline { get; set; }
        public string? BettingType { get; set; }
        public int PositionNumber { get; set; }
        public string? Description { get; set; }
        public string? Choice { get; set; } 
        public decimal Odds { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public GetCouponPositionDTO() {}
    }
}