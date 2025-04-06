using AutoMapper;
using MediatR;
using TestADRES.Application.Common;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Application.Features.BusinessUnits.Queries.GetAllBusinessUnits;
using TestADRES.Application.Features.Suppliers.Queries.GetAllSuppliers;
using TestADRES.Application.Wrappers;
using TestADRES.Domain.Entities;

namespace TestADRES.Application.Features.Requirements.Queries.GetRequirementById
{
    public class GetRequirementByIdQueryHandler : IRequestHandler<GetRequirementByIdQuery, Response<GetRequirementByIdVm>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetRequirementByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Response<GetRequirementByIdVm>> Handle(GetRequirementByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!Guid.TryParse(request.Id, out Guid requirementId))
                {
                    return new Response<GetRequirementByIdVm>(GlobalMessages.InvalidGuidMessage("Id"));
                }

                var requirement = await unitOfWork.RequirementRepository.GetByIdAsync(requirementId);

                if (requirement == null)
                {
                    return new Response<GetRequirementByIdVm>(GlobalMessages.NoRequirementFound);
                }

                return new Response<GetRequirementByIdVm>(await RequirementToMap(requirement), "");
            }
            catch (Exception ex)
            {
                return new Response<GetRequirementByIdVm>(GlobalMessages.ErrorRetrievingRequirementStatuses(ex.Message));
            }
        }

        private async Task<GetRequirementByIdVm> RequirementToMap(Requirement requirement)
        {
            var businessUnit = await unitOfWork.BusinessUnitRepository.GetByIdAsync(requirement.BusinessUnitId);
            var supplier = await unitOfWork.SupplierRepository.GetByIdAsync(requirement.SupplierId);

            return new GetRequirementByIdVm()
            {
                ItemtName = requirement.ItemType.Trim(),
                AcquisitionDate = requirement.AcquisitionDate,
                Budget = requirement.Budget,
                TotalValue = requirement.UnitValue * requirement.Quantity,
                UnitValue = requirement.UnitValue,
                Quantity = requirement.Quantity,
                Documentation = requirement.Documentation.Trim(),
                RequerimentId = requirement.Id,
                BusinessUnitsVm = mapper.Map<BusinessUnitsVm>(businessUnit),
                Supplier = mapper.Map<SuppliersVm>(supplier),
            };
        }


    }
}
