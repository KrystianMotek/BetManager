using BetManager.Domain.Models;
using BetManager.Infrastructure.Database.Repositories;

namespace BetManager.Application.Models.Mappers
{
    public class CouponMapper : ICouponMapper 
    {
        private readonly IDictionaryItemRepository _dictionaryItemRepository;
        
        public CouponMapper(IDictionaryItemRepository dictionaryItemRepository)
        {
            _dictionaryItemRepository = dictionaryItemRepository;
        }

        public Coupon MapToCoupon<T>(T dto)
        {

        }

        public CouponPosition MapToCouponPosition<T>(T dto)
        {
            
        }    

        public GetCouponDTO MapCouponToDTO(Coupon coupon)
        {

        }

        public GetCouponPositionDTO MapCouponPositionToDTO(CouponPosition couponPosition)
        {
            
        }

        private void MapProperties<TSource, TDestination>(TSource source, TDestination destination)
        {
            var dictionaryScopes = _dictionaryItemRepository.GetUniqueScopes();

            foreach (var property in typeof(source).GetProperties()
                    .Where(p => typeof(destination).GetProperty(p.Name)?.CanWrite == true))
            {
                var value = dictionaryScopes.Contains(property.Name)
                    ? _dictionaryItemRepository.GetByScopeAndItemValue(property.Name, property.GetValue(source))
                    : property.GetValue(source);
                
                typeof(destination).GetProperty(property.Name)?.SetValue(destination, value);
            }
        }
    }
}