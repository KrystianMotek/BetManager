using BetManager.Domain.Models;
using BetManager.Application.Models.DTO;

namespace BetManager.Application.Models.Mappers
{   
    public interface ICouponMapper
    {
        Task<Coupon> MapToCouponAsync<T, TCouponPositionDTO>(T dto) 
            where T : ICouponDTO<TCouponPositionDTO>;
        Task<CouponPosition> MapToCouponPositionAsync<T>(T dto)
            where T : ICouponPositionDTO;
        Task<TDestination> MapPropertiesAsync<TSource, TDestination>(TSource source)
            where TDestination : new();
        GetCouponDTO MapFromCoupon(Coupon coupon);
        GetCouponPositionDTO MapFromCouponPosition(CouponPosition couponPosition);
    }
}