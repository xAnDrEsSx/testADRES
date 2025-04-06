using FluentValidation;
using TestADRES.Application.Common;

namespace TestADRES.Application.Features.Requirements.Commands.DeleteRequirement
{
    public class DeleteRequirementCommandValidator : AbstractValidator<DeleteRequirementCommand>
    {
        public DeleteRequirementCommandValidator()
        {
            RuleFor(x => x.RequirementId)
                .NotEmpty().WithMessage(GlobalMessages.GuidValidationMessage("RequirementId"))
                .Must(guid => Guid.TryParse(guid.ToString(), out _)).WithMessage(GlobalMessages.ValidGuidMessage("RequirementId"));
        }
    }
}
