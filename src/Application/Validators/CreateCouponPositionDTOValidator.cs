using FluentValidation;
using BetManager.Application.Models.DTO;

namespace BetManager.Application.Validators
{
    public class CreateCouponPositionDTOValidator : AbstractValidator<CreateCouponPositionDTO> 
    {
        public CreateCouponPositionDTOValidator()
        {
            RuleFor(x => x.Discipline)
                .NotNull()
                .WithMessage("discipline cannot be empty");

            RuleFor(x => x.BettingType)
                .NotNull()
                .WithMessage("bettingType cannot be empty");

            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("description cannot be empty");

            RuleFor(x => x.Choice)
                .NotNull()
                .WithMessage("choice cannot be empty");
            
            RuleFor(x => x.Odds)
                .GreaterThan(0)
                .WithMessage("odds must be greater than zero");
        }
    }
}