using FluentValidation;
using IndexaCapital.Api.Client.Contracts.Questions;

namespace IndexaCapital.Api.Client.ContractValidators.Questions
{
    public sealed class CalculateRiskRequestValidator : AbstractValidator<CalculateRiskRequest>
    {
        public CalculateRiskRequestValidator()
        {
            RuleFor(x => x.Age).InclusiveBetween(0, 99);
            RuleFor(x => x.Wealth).GreaterThanOrEqualTo(50M);
            RuleFor(x => x.Income).GreaterThanOrEqualTo(0M);
        }
    }
}
