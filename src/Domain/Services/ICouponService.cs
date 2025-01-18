using BetManager.Domain.Models;
using BetManager.Application.Models.DTO;

namespace BetManager.Domain.Services
{
    public interface ICouponService
    {
        Task<List<CouponDTO>> GetCouponsAsync();
        Task<Coupon?> GetCouponByIdAsync(Guid id);
        Task<Coupon> CreateCouponAsync(CreateCouponDTO createCouponDTO);
        Task<Coupon> UpdateCouponAsync(CouponDTO couponDTO);
        Task DeleteCouponAsync(Guid id);
    }
}