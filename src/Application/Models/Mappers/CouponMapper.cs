using BetManager.Domain.Models;
using BetManager.Infrastructure.Database;

namespace BetManager.Application.Models.Mappers
{
    public Coupon MapCoupon<T>(T dto)
    {
        var coupon = new Coupon
        {
            Positions = dto.Positions?
                .Select(MapCouponPosition)
                .ToList()
        };

        var dictionaryScopes = _dictionaryItemRepository.GetUniqueScopes();  

        foreach (var property in typeof(CreateCouponDTO).GetProperties()
                .Where(p => typeof(Coupon).GetProperty(p.Name)?.CanWrite == true))
        {
            if (property.Name == "Positions")
                continue;
            
            var value = dictionaryScopes.Contains(property.Name)
                ? _dictionaryItemRepository.GetByScopeAndItemValue(property.Name, property.GetValue(dto))
                : property.GetValue(dto);
            
            typeof(Coupon).GetProperty(property.Name)?.SetValue(coupon, value);
        }

        return coupon;
    }

    public CouponPosition MapCouponPosition<T>(T dto)
    {
        var couponPosition = new CouponPosition();

        var dictionaryScopes = _dictionaryItemRepository.GetUniqueScopes();  

        foreach (var property in typeof(CreateCouponPositionDTO).GetProperties()
                .Where(p => typeof(CouponPosition).GetProperty(p.Name)?.CanWrite == true))
        {
            var value = dictionaryScopes.Contains(property.Name)
                ? _dictionaryItemRepository.GetByScopeAndItemValue(property.Name, property.GetValue(dto))
                : property.GetValue(dto);
            
            typeof(CouponPosition).GetProperty(property.Name)?.SetValue(couponPosition, value);
        }

        return couponPosition;
    }    
}