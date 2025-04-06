using MediatR;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.RequirementStatuses.Queries.GetAllRequirementStatuses
{
    public class GetAllRequirementStatusesQuery : IRequest<Response<List<RequirementStatusesVm>>>
    {
    }
}
