using FluentValidation;
using TestADRES.Application.Common;

namespace TestADRES.Application.Features.Requirements.Commands.UpdateRequirement
{
    public class UpdateRequirementCommandValidator : AbstractValidator<UpdateRequirementCommand>
    {
        public UpdateRequirementCommandValidator()
        {
            RuleFor(p => p.SupplierId)
                .NotEmpty().WithMessage(GlobalMessages.GuidValidationMessage("SupplierId"))
                .Must(guid => Guid.TryParse(guid.ToString(), out _)).WithMessage(GlobalMessages.ValidGuidMessage("SupplierId"))
                .When(p => p.SupplierId.HasValue);

            RuleFor(p => p.ItemType)
                .NotEmpty().WithMessage(GlobalMessages.NotEmptyMessage("ItemType"))
                .MinimumLength(5).WithMessage(GlobalMessages.MinLengthMessage("ItemType", 5))
                .When(p => !string.IsNullOrEmpty(p.ItemType));

            RuleFor(p => p.Budget)
                .GreaterThan(0).WithMessage(GlobalMessages.GreaterThanZeroMessage("Budget"))
                .NotNull().WithMessage(GlobalMessages.NotNullMessage("Budget"))
                .When(p => p.Budget.HasValue);

            RuleFor(p => p.BusinessUnitId)
                .GreaterThan(0).WithMessage(GlobalMessages.GreaterThanZeroMessage("BusinessUnitId"))
                .NotNull().WithMessage(GlobalMessages.NotNullMessage("BusinessUnitId"))
                .When(p => p.BusinessUnitId.HasValue);

            RuleFor(p => p.Quantity)
                .GreaterThan(0).WithMessage(GlobalMessages.GreaterThanZeroMessage("Quantity"))
                .NotNull().WithMessage(GlobalMessages.NotNullMessage("Quantity"))
                .When(p => p.Quantity.HasValue);

            RuleFor(p => p.UnitValue)
                .GreaterThan(0).WithMessage(GlobalMessages.GreaterThanZeroMessage("UnitValue"))
                .NotNull().WithMessage(GlobalMessages.NotNullMessage("UnitValue"))
                .When(p => p.UnitValue.HasValue);

            RuleFor(p => p.AcquisitionDate)
                .NotEmpty().WithMessage(GlobalMessages.NotEmptyMessage("AcquisitionDate"))
                .LessThanOrEqualTo(DateTime.Now).WithMessage(GlobalMessages.ValidDateMessage("AcquisitionDate"))
                .When(p => p.AcquisitionDate.HasValue);

            RuleFor(p => p.Documentation)
                .NotEmpty().WithMessage(GlobalMessages.NotEmptyMessage("Documentation"))
                .MinimumLength(5).WithMessage(GlobalMessages.MinLengthMessage("Documentation", 5))
                .When(p => !string.IsNullOrEmpty(p.Documentation));

        }
    }
}
