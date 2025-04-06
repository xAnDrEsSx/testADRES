using FluentValidation;
using TestADRES.Application.Common;

namespace TestADRES.Application.Features.Requirements.Commands.CreateRequirement
{
    public class CreateRequirementCommandValidator : AbstractValidator<CreateRequirementCommand>
    {
        public CreateRequirementCommandValidator()
        {
            #region Mensajes de validación

            RuleFor(p => p.SupplierId)
                .NotEmpty().WithMessage(GlobalMessages.GuidValidationMessage("SupplierId"))
                .Must(guid => Guid.TryParse(guid.ToString(), out _)).WithMessage(GlobalMessages.ValidGuidMessage("SupplierId"));

            RuleFor(p => p.ItemType)
                .NotEmpty().WithMessage(GlobalMessages.NotEmptyMessage("ItemType"))
                .MinimumLength(5).WithMessage(GlobalMessages.MinLengthMessage("ItemType", 5));

            RuleFor(p => p.Budget)
                .GreaterThan(0).WithMessage(GlobalMessages.GreaterThanZeroMessage("Budget"))
                .NotNull().WithMessage(GlobalMessages.NotNullMessage("Budget"));

            RuleFor(p => p.BusinessUnitId)
                .GreaterThan(0).WithMessage(GlobalMessages.GreaterThanZeroMessage("BusinessUnitId"))
                .NotNull().WithMessage(GlobalMessages.NotNullMessage("BusinessUnitId"));

            RuleFor(p => p.Quantity)
                .GreaterThan(0).WithMessage(GlobalMessages.GreaterThanZeroMessage("Quantity"))
                .NotNull().WithMessage(GlobalMessages.NotNullMessage("Quantity"));

            RuleFor(p => p.UnitValue)
                .GreaterThan(0).WithMessage(GlobalMessages.GreaterThanZeroMessage("UnitValue"))
                .NotNull().WithMessage(GlobalMessages.NotNullMessage("UnitValue"));

            RuleFor(p => p.AcquisitionDate)
                .NotEmpty().WithMessage(GlobalMessages.NotEmptyMessage("AcquisitionDate"))
                .LessThanOrEqualTo(DateTime.Now).WithMessage(GlobalMessages.ValidDateMessage("AcquisitionDate"));

            RuleFor(p => p.Documentation)
                .NotEmpty().WithMessage(GlobalMessages.NotEmptyMessage("Documentation"))
                .MinimumLength(5).WithMessage(GlobalMessages.MinLengthMessage("Documentation", 5));

            RuleFor(p => p.CreatedByUserId)
                .NotEmpty().WithMessage(GlobalMessages.GuidValidationMessage("CreatedByUserId"))
                .Must(guid => Guid.TryParse(guid.ToString(), out _)).WithMessage(GlobalMessages.ValidGuidMessage("CreatedByUserId"));

            #endregion

            #region Validación adicional de Quantity * UnitValue <= Budget

            RuleFor(p => p.Quantity * p.UnitValue)
                .LessThanOrEqualTo(p => p.Budget).WithMessage("The total value (Quantity * UnitValue) cannot exceed the Budget.");

            #endregion
        }
    }
}
