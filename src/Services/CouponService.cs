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
        private readonly IDictionaryItemRepository _dictionaryItemRepository;

        public CouponService(ICouponRepository couponRepository, IDictionaryItemRepository dictionaryItemRepository)
        {
            _couponRepository = couponRepository;
            _dictionaryItemRepository = dictionaryItemRepository;
        }

        public async Task<List<Coupon>> GetCouponsAsync()
        {
            return await _couponRepository.GetAllAsync();
        }

        public async Task<Coupon?> GetCouponByIdAsync(Guid id)
        {
            var coupon = await _couponRepository.GetByIdAsync(id) 
                ?? throw new KeyNotFoundException("coupon not found");

            return coupon;
        }

        public async Task<Coupon> CreateCouponAsync(CreateCouponDTO createCouponDTO)
        {
            var status = await _dictionaryItemRepository.GetByScopeAndItemValueAsync("Status", "pending");

            var couponType = await _dictionaryItemRepository.GetByScopeAndItemValueAsync("CouponType", createCouponDTO.CouponType.ItemValue);

            var coupon = new Coupon
            {
                Status = status,
                CouponType = couponType,
                CouponNumber = createCouponDTO.CouponNumber,
                ConclusionTime = createCouponDTO.ConclusionTime,
                PossibleProfit = createCouponDTO.PossibleProfit,
                TotalOdds = createCouponDTO.TotalOdds,
                TaxAmount = createCouponDTO.TaxAmount,
                TaxRate = createCouponDTO.TaxRate,
                Stake = createCouponDTO.Stake
            };

            coupon.Positions = new List<CouponPosition>();

            foreach (var createCouponPositionDTO in createCouponDTO.Positions)
            {
                var discipline = await _dictionaryItemRepository.GetByScopeAndItemValueAsync("Discipline", createCouponPositionDTO.Discipline.ItemValue);

                var bettingType = await _dictionaryItemRepository.GetByScopeAndItemValueAsync("BettingType", createCouponPositionDTO.BettingType.ItemValue);

                var position = new CouponPosition
                {
                    Coupon = coupon,
                    Status = status,
                    Discipline = discipline,
                    BettingType = bettingType,
                    Description = createCouponPositionDTO.Description,
                    Choice = createCouponPositionDTO.Choice,
                    Odds = createCouponPositionDTO.Odds 
                };

                coupon.Positions.Add(position);
            }

            await _couponRepository.CreateAsync(coupon);

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