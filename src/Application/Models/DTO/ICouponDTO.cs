namespace BetManager.Application.Models.DTO
{
    public interface ICouponDTO<TCouponPositionDTO>
    {
        List<TCouponPositionDTO>? Positions { get; set; }
    }    
}