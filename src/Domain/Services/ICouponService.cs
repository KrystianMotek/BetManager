using BetManager.Domain.Models;
using BetManager.Application.Models.DTO;

namespace BetManager.Domain.Services
{
    public interface ICouponService
    {
        // filtering is required to prevent to much records returned
        Task<List<Coupon>> GetCouponsAsync(); 
        Task<Coupon?> GetCouponByIdAsync(Guid id);
        Task<Coupon> CreateCouponAsync(CreateCouponDTO createCouponDTO);
        Task<Coupon?> DeleteCouponAsync(Guid id);
    }
}