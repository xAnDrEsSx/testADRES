using MediatR;
using TestADRES.Application.Features.Requirements.Queries.GetAllRequirement;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.Requirements.Queries.GetFilteredRequirements
{
    public class GetFilteredRequirementsQuery : IRequest<Response<List<GetAllRequirementVm>>>
    {
        public Guid? SupplierId { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? RequirementStatusId { get; set; }
        public string? ItemType { get; set; }
    }
}
