using System.Reflection;
using BetManager.Domain.Models;
using BetManager.Domain.Services;
using BetManager.Domain.Repositories;
using BetManager.Application.Models.DTO;   
using BetManager.Infrastructure.Database.Repositories;

namespace BetManager.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        private readonly ICouponPositionRepository _couponPositionRepository;
        private readonly IDictionaryItemRepository _dictionaryItemRepository;

        public CouponService(
            ICouponRepository couponRepository, 
            ICouponPositionRepository couponPositionRepository, 
            IDictionaryItemRepository dictionaryItemRepository
        )
        {
            _couponRepository = couponRepository;
            _couponPositionRepository = couponPositionRepository;
            _dictionaryItemRepository = dictionaryItemRepository;
        }

        public async Task<Coupon?> GetCouponByIdAsync(Guid id)
        {
            var coupon = await _couponRepository.GetByIdAsync(id) 
                ?? throw new KeyNotFoundException("coupon not found");

            return coupon;
        }

        public async Task<List<string>> GetUniqueDictionaryScopesAsync()
        {
            return await _dictionaryItemRepository.GetUniqueScopesAsync();
        }

        public async Task<DictionaryItem> GetDictionaryItemByScopeAndValueAsync(string scope, string value)
        {
            var dictionaryItem = await _dictionaryItemRepository.GetByScopeAndItemValueAsync(scope, value)
                ?? throw new KeyNotFoundException("no matching dictionary object");

            return dictionaryItem;
        }

        public async Task<List<Coupon>> GetCouponsInConclusionTimeRangeAsync(DateTime timeFrom, DateTime timeTo)
        {
            return await _couponRepository.GetInConclusionTimeRangeAsync(timeFrom, timeTo);
        }

        public async Task<Coupon> CreateCouponAsync(Coupon coupon)
        {
            await _couponRepository.CreateAsync(coupon);
            return coupon;
        }

        public async Task<Coupon> UpdateCouponAsync(Coupon coupon)
        {
            await _couponRepository.UpdateAsync(coupon);
            return coupon;
        }

        public async Task<Coupon?> DeleteCouponAsync(Guid id)
        {
            var coupon = await _couponRepository.GetByIdAsync(id) 
                ?? throw new KeyNotFoundException("coupon not found");
            
            await _couponRepository.DeleteAsync(coupon);

            return coupon;
        }
    }
}