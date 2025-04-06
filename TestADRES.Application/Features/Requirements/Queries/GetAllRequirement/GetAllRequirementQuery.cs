using MediatR;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.Requirements.Queries.GetAllRequirement
{
    public class GetAllRequirementQuery : IRequest<Response<List<GetAllRequirementVm>>>
    {
    }
}
