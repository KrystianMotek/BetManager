using BetManager.Domain.Models;
using BetManager.Domain.Services;
using BetManager.Application.Models.DTO;

namespace BetManager.Application.Models.Mappers
{
    public class CouponMapper : ICouponMapper 
    {
        private readonly ICouponService _couponService;
        
        public CouponMapper(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<Coupon> MapToCouponAsync<T, TCouponPositionDTO>(T dto)
            where T : ICouponDTO<TCouponPositionDTO> 
        {   
            var coupon = await MapPropertiesAsync<T, Coupon>(dto);

            if (dto.Positions != null)
            {
                coupon.Positions = new List<CouponPosition>();
                foreach (var dtoPosition in dto.Positions)
                {
                    var position = await MapPropertiesAsync<TCouponPositionDTO, CouponPosition>(dtoPosition);
                    coupon.Positions.Add(position);
                }
            }

            return coupon;
        }

        public async Task<CouponPosition> MapToCouponPositionAsync<T>(T dto) 
            where T : ICouponPositionDTO
        {   
            return await MapPropertiesAsync<T, CouponPosition>(dto);
        }    

        public async Task<TDestination> MapPropertiesAsync<TSource, TDestination>(TSource source) 
            where TDestination : new() 
        {
            var destination = new TDestination();
            var destinationType = typeof(TDestination);
            var dictionaryScopes = await _couponService.GetUniqueDictionaryScopesAsync();

            foreach (var property in typeof(TSource).GetProperties()
                    .Where(p => p.Name != "Positions" && destinationType.GetProperty(p.Name)?.CanWrite == true))
            {
                var sourceValue = property.GetValue(source);

                var destinationValue = dictionaryScopes.Contains(property.Name)
                    ? await _couponService.GetDictionaryItemByScopeAndValueAsync(property.Name, sourceValue?.ToString() ?? string.Empty)
                    : sourceValue;
                
                destinationType.GetProperty(property.Name)?.SetValue(destination, destinationValue);
            }

            return destination;
        }

        public GetCouponDTO MapFromCoupon(Coupon coupon)
        {
            var dto = new GetCouponDTO();

            dto.Id = coupon.Id;
            dto.CreatedAt = coupon.CreatedAt;
            dto.ModifiedAt = coupon.ModifiedAt;
            dto.ConclusionTime = coupon.ConclusionTime;
            dto.PossibleProfit = coupon.PossibleProfit;
            dto.TotalOdds = coupon.TotalOdds;
            dto.TaxAmount = coupon.TaxAmount;
            dto.TaxRate = coupon.TaxRate;
            dto.Stake = coupon.Stake;

            dto.Status = coupon.Status?.ItemValue
                ?? string.Empty;
            dto.CouponType = coupon.CouponType?.ItemValue
                ?? string.Empty;
            dto.CouponNumber = coupon.CouponNumber
                ?? string.Empty;

            if (coupon.Positions != null)
            {
                dto.Positions = new List<GetCouponPositionDTO>();
                foreach (var position in coupon.Positions)
                {
                    dto.Positions.Add(MapFromCouponPosition(position));
                }
            }

            return dto;
        }

        public GetCouponPositionDTO MapFromCouponPosition(CouponPosition couponPosition)
        {
            var dto = new GetCouponPositionDTO();

            dto.Id = couponPosition.Id;
            dto.PositionNumber = couponPosition.PositionNumber;
            dto.ModifiedAt = couponPosition.ModifiedAt;
            dto.CreatedAt = couponPosition.CreatedAt;
            dto.Odds = couponPosition.Odds;

            dto.Status = couponPosition.Status?.ItemValue 
                ?? string.Empty;
            dto.Discipline = couponPosition.Discipline?.ItemValue
                ?? string.Empty;
            dto.BettingType = couponPosition.BettingType?.ItemValue
                ?? string.Empty;
            dto.Description = couponPosition.Description 
                ?? string.Empty;
            dto.Choice = couponPosition.Choice 
                ?? string.Empty;

            return dto;
        }
    }
}