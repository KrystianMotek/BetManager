using BetManager.Domain.Models;

namespace BetManager.Domain.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon?> GetByIdAsync(Guid id);
        Task<Coupon?> GetByCouponNumberAsync(string couponNumber);
        Task<Coupon> CreateAsync(Coupon coupon);
        Task<Coupon> UpdateAsync(Coupon coupon);
        Task<Coupon> DeleteAsync(Coupon coupon);
    }
}