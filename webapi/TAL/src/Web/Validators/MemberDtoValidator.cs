using FluentValidation;
using TAL.WebApi.Dtos;

namespace TAL.WebApi.Validators
{

    public class MemberDtoValidator : AbstractValidator<MemberDto>
    {
        public MemberDtoValidator()
        {
            RuleFor(x => x.OccupationId).NotNull().GreaterThan(0).WithMessage("Occupation can not be null!");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required!");
            RuleFor(x => x.DeathSumInsured).NotEmpty().WithMessage("DeathSumInsured is required!");
        }
    }
}
