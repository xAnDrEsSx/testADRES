using MediatR;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Application.Wrappers;

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

                // Actualizar solo los campos que vienen en el request
                if (request.SupplierId.HasValue)
                    requirement.SupplierId = request.SupplierId.Value;

                if (!string.IsNullOrEmpty(request.ItemType))
                    requirement.ItemType = request.ItemType;

                if (request.Budget.HasValue)
                    requirement.Budget = request.Budget.Value;

                if (request.BusinessUnitId.HasValue)
                    requirement.BusinessUnitId = request.BusinessUnitId.Value;

                if (request.Quantity.HasValue)
                    requirement.Quantity = request.Quantity.Value;

                if (request.UnitValue.HasValue)
                    requirement.UnitValue = request.UnitValue.Value;

                if (request.AcquisitionDate.HasValue)
                    requirement.AcquisitionDate = request.AcquisitionDate.Value;

                if (!string.IsNullOrEmpty(request.Documentation))
                    requirement.Documentation = request.Documentation;

                // Actualizar el Requirement
                unitOfWork.RequirementRepository.UpdateEntity(requirement);
                var result = await unitOfWork.Complete();

                if (result > 0)
                {
                    return new Response<bool>(true, "Requirement updated successfully.");
                }

                return new Response<bool>(false, "Failed to update requirement.");
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message);
            }
        }
    }
}
