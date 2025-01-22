using BetManager.Domain.Models;

namespace BetManager.Domain.Services
{
    public interface ICouponService
    {
        // filtering is required to prevent too much records returned
        Task<List<Coupon>> GetCouponsAsync(); 
        Task<Coupon?> GetCouponByIdAsync(Guid id);
        Task<Coupon> CreateCouponAsync(Coupon coupon);
        Task<Coupon?> DeleteCouponAsync(Guid id);
    }
}