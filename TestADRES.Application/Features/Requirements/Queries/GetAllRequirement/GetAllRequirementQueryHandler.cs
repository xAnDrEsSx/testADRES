using AutoMapper;
using MediatR;
using TestADRES.Application.Common;
using TestADRES.Application.Common.enums;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.Requirements.Queries.GetAllRequirement
{
    public class GetAllRequirementQueryHandler : IRequestHandler<GetAllRequirementQuery, Response<List<GetAllRequirementVm>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllRequirementQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Response<List<GetAllRequirementVm>>> Handle(GetAllRequirementQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var requirements = await unitOfWork.RequirementRepository.GetAllAsync();

                if (requirements == null || !requirements.Any())
                {
                    return new Response<List<GetAllRequirementVm>>([], GlobalMessages.NoSuppliersFound);
                }

                var requirementsList = new List<GetAllRequirementVm>();

                foreach (var requirement in requirements.Where(r => r.RequirementStatusId == (int)RequirementStatusEnum.Activo).OrderByDescending(o => o.CreatedDate))
                {
                    requirementsList.Add(new GetAllRequirementVm()
                    {
                        RequerimentId = requirement.Id,
                        AcquisitionDate = requirement.AcquisitionDate,
                        ItemtName = requirement.ItemType.Trim(),
                        TotalValue = requirement.UnitValue * requirement.Quantity,
                        UnitName = unitOfWork.BusinessUnitRepository.GetByIdAsync(requirement.BusinessUnitId).Result.Name.Trim(),
                    });
                };

                return new Response<List<GetAllRequirementVm>>(requirementsList, "");

            }
            catch (Exception ex)
            {
                return new Response<List<GetAllRequirementVm>>(GlobalMessages.ErrorRetrievingSuppliers(ex.Message));
            }
        }
    }
}
