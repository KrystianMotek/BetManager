using FluentValidation;
using BetManager.Application.Models.DTO;

namespace BetManager.Application.Validators
{
    public class CreateCouponDTOValidator : AbstractValidator<CreateCouponDTO> 
    {
        public CreateCouponDTOValidator()
        {
            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("status cannot be empty");

            RuleFor(x => x.CouponType)
                .NotNull()
                .WithMessage("couponType cannot be empty");

            RuleFor(x => x.CouponNumber)
                .NotNull()
                .WithMessage("couponNumber cannot be empty");

            RuleFor(x => x.ConclusionTime)
                .LessThan(DateTime.Now)
                .WithMessage("conclusionTime must be in the past");

            RuleFor(x => x.PossibleProfit)
                .GreaterThan(0)
                .WithMessage("possibleProfit must be greater than zero");

            RuleFor(x => x.TotalOdds)
                .GreaterThan(0)
                .WithMessage("totalOdds must be greater than zero");

            RuleFor(x => x.TaxAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("taxAmount must be greater than or equal to zero");

            RuleFor(x => x.TaxRate)
                .GreaterThanOrEqualTo(0)
                .WithMessage("taxRate must be greater than or equal to zero");

            RuleFor(x => x.Stake)
                .GreaterThan(0)
                .WithMessage("stake must be greater than zero");

            RuleForEach(x => x.Positions)
                .SetValidator(new CreateCouponPositionDTOValidator());
        }
    } 
}