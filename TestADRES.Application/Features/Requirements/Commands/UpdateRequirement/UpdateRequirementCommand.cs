using MediatR;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.Requirements.Commands.UpdateRequirement
{
    public class UpdateRequirementCommand : IRequest<Response<bool>>
    {
        public Guid RequirementId { get; set; }

        public Guid? SupplierId { get; set; }

        public string? ItemType { get; set; }

        public decimal? Budget { get; set; }

        public int? BusinessUnitId { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? UnitValue { get; set; }

        public DateTime? AcquisitionDate { get; set; }

        public string? Documentation { get; set; }

    }
}
