namespace BetManager.Application.Models.DTO
{
    public interface ICouponDTO<TCouponPositionDTO> : IDTO 
    {
        List<TCouponPositionDTO> Positions { get; set; }
    }    
}