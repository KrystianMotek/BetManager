using BetManager.Domain.Models;

namespace BetManager.Domain.Services
{
    public interface ICouponService
    {
        Task<Coupon?> GetCouponByIdAsync(Guid id);
        Task<Coupon?> GetCouponByCouponNumberAsync(string couponNumber); 
    }
}