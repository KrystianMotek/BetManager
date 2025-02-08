using FluentValidation;
using BetManager.Application.Models.DTO;

namespace BetManager.Application.Validators
{
    public class CouponDTOValidator<T> : AbstractValidator<T> 
        where T : ICouponDTO
    {
        public CouponDTOValidator()
        {
            
        }
    } 
}