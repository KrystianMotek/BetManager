using BetManager.Domain.Models;

namespace BetManager.Domain.Repositories
{
    public interface ICouponPositionRepository
    {
        public Task<CouponPosition?> GetByIdAsync(Guid id);
        public Task<CouponPosition> CreateAsync(CouponPosition couponPosition);
        public Task<CouponPosition> UpdateAsync(CouponPosition couponPosition);
        public Task<CouponPosition> DeleteAsync(CouponPosition couponPosition);
    }
}