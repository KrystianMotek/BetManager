using BetManager.Domain.Models;
using BetManager.Application.Models.DTO;

namespace BetManager.Application.Models.Mappers
{   
    public interface ICouponMapper
    {
        public Task<Coupon> MapToCouponAsync<T, TCouponPositionDTO>(T dto) 
            where T : ICouponDTO<TCouponPositionDTO>;

        public Task<CouponPosition> MapToCouponPositionAsync<T>(T dto)
            where T : ICouponPositionDTO;

        public Task<TDestination> MapPropertiesAsync<TSource, TDestination>(TSource source)
            where TDestination : new();
    }
}