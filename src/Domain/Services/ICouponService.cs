using BetManager.Domain.Models;

namespace BetManager.Domain.Services
{
    public interface ICouponService
    {
        Task<Coupon?> GetCouponByIdAsync(Guid id);
        Task<Coupon> CreateCouponAsync(Coupon coupon);
        Task<List<Coupon>> GetCouponsInConclusionTimeRangeAsync(DateTime timeFrom, DateTime timeTo); 
        Task<Coupon> UpdateCouponAsync(Coupon coupon);
        Task<Coupon?> DeleteCouponAsync(Guid id);
    }
}