using BetManager.Domain.Models;
using BetManager.Application.Models.DTO;

namespace BetManager.Domain.Services
{
    public interface ICouponService
    {
        Task<Coupon?> GetCouponByIdAsync(Guid id);
        Task<List<string>> GetUniqueDictionaryScopesAsync();
        Task<DictionaryItem?> GetDictionaryItemByScopeAndValueAsync(string scope, string value); 
        Task<List<Coupon>> GetCouponsInConclusionTimeRangeAsync(DateTime timeFrom, DateTime timeTo);
        Task<Coupon> CreateCouponAsync(Coupon coupon); 
        Task<Coupon> UpdateCouponAsync(Coupon coupon);
        Task<Coupon?> DeleteCouponAsync(Guid id);
    }
}