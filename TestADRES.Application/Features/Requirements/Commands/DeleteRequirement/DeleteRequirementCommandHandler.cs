using MediatR;
using TestADRES.Application.Common.enums;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Application.Wrappers;
using TestADRES.Application.Common;

namespace TestADRES.Application.Features.Requirements.Commands.DeleteRequirement
{
    public class DeleteRequirementCommandHandler : IRequestHandler<DeleteRequirementCommand, Response<bool>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteRequirementCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(DeleteRequirementCommand request, CancellationToken cancellationToken)
        {
            var requirement = await unitOfWork.RequirementRepository.GetByIdAsync(request.RequirementId);

            if (requirement == null)
            {
                return new Response<bool>(false, GlobalMessages.NoRequirementFound);
            }

            requirement.RequirementStatusId = (int)RequirementStatusEnum.Inactivo;
            unitOfWork.RequirementRepository.UpdateEntity(requirement);

            var result = await unitOfWork.Complete();

            return result > 0
                ? new Response<bool>(true, $"Requirement with ID {request.RequirementId} marked as inactive successfully.")
                : new Response<bool>(false, GlobalMessages.ErrorRetrievingRequirementStatuses("Unable to delete requirement."));
        }
    }
}
