using BetManager.Domain.Models;
using BetManager.Domain.Repositories;
using BetManager.Application.Models.DTO;
namespace BetManager.Application.Models.Mappers
{
    public class CouponMapper : ICouponMapper 
    {
        private readonly IDictionaryItemRepository _dictionaryItemRepository;
        
        public CouponMapper(IDictionaryItemRepository dictionaryItemRepository)
        {
            _dictionaryItemRepository = dictionaryItemRepository;
        }

        public async Task<Coupon> MapToCouponAsync<T, TCouponPositionDTO>(T dto)
            where T : ICouponDTO<TCouponPositionDTO> 
        {   
            var coupon = await MapPropertiesAsync<T, Coupon>(dto);

            foreach (var dtoPosition in dto.Positions)
            {
                var position = await MapPropertiesAsync<TCouponPositionDTO, CouponPosition>(dtoPosition);
                
                coupon.Positions.Add(position);
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

            var dictionaryScopes = await _dictionaryItemRepository.GetUniqueScopesAsync();

            foreach (var property in typeof(TSource).GetProperties()
                    .Where(p => p.Name != "Positions" && typeof(TDestination).GetProperty(p.Name)?.CanWrite == true))
            {
                var value = dictionaryScopes.Contains(property.Name)
                    ? _dictionaryItemRepository.GetByScopeAndItemValueAsync(property.Name, property.GetValue(source).ToString())
                    : property.GetValue(source);
                
                typeof(TDestination).GetProperty(property.Name)?.SetValue(destination, value);
            }

            return destination;
        }
    }
}