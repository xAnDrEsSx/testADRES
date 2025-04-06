using MediatR;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.Requirements.Commands.DeleteRequirement
{
    public class DeleteRequirementCommand : IRequest<Response<bool>>
    {
        public Guid RequirementId { get; set; }

    }
}
