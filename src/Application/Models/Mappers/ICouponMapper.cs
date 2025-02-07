using BetManager.Domain.Models;

using namespace BetManager.Application.Models.Mappers
{   
    public interface ICouponMapper
    {
        public Coupon MapCoupon<T>(T dto);
        public CouponPosition MapCouponPosition<T>(T dto);
        private void MapProperties<TSource, TDestination>(TSource source, TDestination destination);
    }
}