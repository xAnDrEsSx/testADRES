using AutoMapper;
using MediatR;
using TestADRES.Application.Common;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.RequirementStatuses.Queries.GetAllRequirementStatuses
{
    public class GetAllRequirementStatusesQueryHandler : IRequestHandler<GetAllRequirementStatusesQuery, Response<List<RequirementStatusesVm>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllRequirementStatusesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Response<List<RequirementStatusesVm>>> Handle(GetAllRequirementStatusesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var requirementStatuses = await unitOfWork.RequirementStatusRepository.GetAllAsync();

                if (requirementStatuses == null || !requirementStatuses.Any())
                {
                    return new Response<List<RequirementStatusesVm>>([], GlobalMessages.NoRequirementStatusesFound);
                }

                return new Response<List<RequirementStatusesVm>>(mapper.Map<List<RequirementStatusesVm>>(requirementStatuses), GlobalMessages.RequirementStatusesRetrievedSuccessfully);

            }
            catch (Exception ex)
            {
                return new Response<List<RequirementStatusesVm>>(GlobalMessages.ErrorRetrievingRequirementStatuses(ex.Message));
            }
        }
    }
}
