using MediatR;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.Requirements.Queries.GetRequirementById
{
    public class GetRequirementByIdQuery : IRequest<Response<GetRequirementByIdVm>>
    {
        public string Id { get; set; }

        public GetRequirementByIdQuery(string id)
        {
            Id = id;
        }
    }

}
