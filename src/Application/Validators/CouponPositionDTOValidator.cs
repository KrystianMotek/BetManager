using FluentValidation;
using BetManager.Application.Models.DTO;

namespace BetManager.Application.Validators
{
    public class CouponPositionDTOValidator<T> : AbstractValidator<T> 
        where T : ICouponPositionDTO
    {
        public CouponPositionDTOValidator()
        {

        }
    }
}