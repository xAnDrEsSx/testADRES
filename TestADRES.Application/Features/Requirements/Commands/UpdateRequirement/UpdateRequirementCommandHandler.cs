using MediatR;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Application.Wrappers;
using TestADRES.Domain.Entities;


namespace TestADRES.Application.Features.Requirements.Commands.UpdateRequirement
{
    public class UpdateRequirementCommandHandler : IRequestHandler<UpdateRequirementCommand, Response<bool>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateRequirementCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(UpdateRequirementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Obtener la entidad existente
                var requirement = await unitOfWork.RequirementRepository.GetByIdAsync(request.RequirementId);

                if (requirement == null)
                {
                    return new Response<bool>(false, "Requirement not found.");
                }

                // Lista para registrar los cambios históricos
                List<HistoricalRequirement> historicalChanges = [];

                // Actualizar solo los campos que vienen en el request
                if (request.SupplierId.HasValue && requirement.SupplierId != request.SupplierId.Value)
                {
                    await UpdateFieldIfChanged("SupplierId", requirement.SupplierId, request.SupplierId.Value, historicalChanges, requirement, r => r.SupplierId = request.SupplierId.Value);
                }

                if (!string.IsNullOrEmpty(request.ItemType) && requirement.ItemType != request.ItemType)
                {
                    await UpdateFieldIfChanged("ItemType", requirement.ItemType, request.ItemType, historicalChanges, requirement, r => r.ItemType = request.ItemType);
                }

                if (request.Budget.HasValue && requirement.Budget != request.Budget.Value)
                {
                    await UpdateFieldIfChanged("Budget", requirement.Budget, request.Budget.Value, historicalChanges, requirement, r => r.Budget = request.Budget.Value);
                }

                if (request.BusinessUnitId.HasValue && requirement.BusinessUnitId != request.BusinessUnitId.Value)
                {
                    await UpdateFieldIfChanged("BusinessUnitId", requirement.BusinessUnitId, request.BusinessUnitId.Value, historicalChanges, requirement, r => r.BusinessUnitId = request.BusinessUnitId.Value);
                }

                if (request.Quantity.HasValue && requirement.Quantity != request.Quantity.Value)
                {
                    await UpdateFieldIfChanged("Quantity", requirement.Quantity, request.Quantity.Value, historicalChanges, requirement, r => r.Quantity = request.Quantity.Value);
                }

                if (request.UnitValue.HasValue && requirement.UnitValue != request.UnitValue.Value)
                {
                    await UpdateFieldIfChanged("UnitValue", requirement.UnitValue, request.UnitValue.Value, historicalChanges, requirement, r => r.UnitValue = request.UnitValue.Value);
                }

                if (request.AcquisitionDate.HasValue && requirement.AcquisitionDate != request.AcquisitionDate.Value)
                {
                    await UpdateFieldIfChanged("AcquisitionDate", requirement.AcquisitionDate, request.AcquisitionDate.Value, historicalChanges, requirement, r => r.AcquisitionDate = request.AcquisitionDate.Value);
                }

                if (!string.IsNullOrEmpty(request.Documentation) && requirement.Documentation != request.Documentation)
                {
                    await UpdateFieldIfChanged("Documentation", requirement.Documentation, request.Documentation, historicalChanges, requirement, r => r.Documentation = request.Documentation);
                }

                // Actualizar el Requirement
                unitOfWork.RequirementRepository.UpdateEntity(requirement);
                var result = await unitOfWork.Complete();

                if (result > 0)
                {
                    // Guardar los cambios históricos
                    if (historicalChanges.Any())
                    {
                        await unitOfWork.HistoricalRequirementRepository.AddRangeAsync(historicalChanges);
                    }

                    return new Response<bool>(true, "Requirement updated successfully.");
                }

                return new Response<bool>(false, "Failed to update requirement.");
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message);
            }
        }

        private async Task UpdateFieldIfChanged<T>(
            string fieldName,
            T currentValue,
            T newValue,
            List<HistoricalRequirement> historicalChanges,
            Requirement requirement,
            Action<Requirement> fieldSelector)
        {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue)) return;

            historicalChanges.Add(new HistoricalRequirement
            {
                FieldName = fieldName,
                OldValue = currentValue?.ToString() ?? string.Empty,
                NewValue = newValue?.ToString() ?? string.Empty,
                RequirementId = requirement.Id,
                ChangedBy = requirement.CreatedByUserId,
                ChangeDate = DateTime.Now
            });

            fieldSelector(requirement);
        }
    }
}
