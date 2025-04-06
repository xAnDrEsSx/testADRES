using MediatR;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.Requirements.Commands.CreateRequirement
{
    public record CreateRequirementCommand : IRequest<Response<Guid>>
    {

        public Guid SupplierId { get; set; }

        public string ItemType { get; set; } = string.Empty;

        public decimal Budget { get; set; } = 0;

        public int BusinessUnitId { get; set; }

        public decimal Quantity { get; set; } = 0;

        public decimal UnitValue { get; set; } = 0;

        public DateTime AcquisitionDate { get; set; }

        public string Documentation { get; set; } = string.Empty;

        public Guid CreatedByUserId { get; set; }
    }
}
