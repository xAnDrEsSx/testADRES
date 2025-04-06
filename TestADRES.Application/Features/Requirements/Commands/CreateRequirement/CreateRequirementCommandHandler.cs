using AutoMapper;
using MediatR;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Application.Exceptions;
using TestADRES.Application.Wrappers;
using TestADRES.Domain.Entities;
using TestADRES.Application.Common.enums;

namespace TestADRES.Application.Features.Requirements.Commands.CreateRequirement
{
    public class CreateRequirementCommandHandler : IRequestHandler<CreateRequirementCommand, Response<Guid>>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateRequirementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateRequirementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(await unitOfWork.BusinessUnitRepository.GetByIdAsync(request.BusinessUnitId) == null)
                {
                    throw new NotFoundException("BusinessUnit", request.BusinessUnitId);
                }

                if (await unitOfWork.SupplierRepository.GetByIdAsync(request.SupplierId) == null)
                {
                    throw new NotFoundException("Supplier", request.BusinessUnitId);
                }

                //if (await unitOfWork.BusinessUnitRepository.GetByIdAsync(request.BusinessUnitId) == null)
                //{
                //    throw new NotFoundException("User", request.CreatedByUserId);
                //}

                var requirement = mapper.Map<Requirement>(request);
                requirement.RequirementStatusId = (int)RequirementStatusEnum.Activo;

                unitOfWork.RequirementRepository.AddEntity(requirement);
                var result = await unitOfWork.Complete();
                return result <= 0 ? new Response<Guid>("Unable to create requirement!") : new Response<Guid>(requirement.Id, "Requirement Created!");
            }
            catch (Exception ex)
            {
                return new Response<Guid>(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
