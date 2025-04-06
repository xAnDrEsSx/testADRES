using TestADRES.Application.Features.BusinessUnits.Queries.GetAllBusinessUnits;
using TestADRES.Application.Features.Suppliers.Queries.GetAllSuppliers;

namespace TestADRES.Application.Features.Requirements.Queries.GetRequirementById
{
    public class GetRequirementByIdVm
    {
        public Guid RequerimentId { get; set; }
        public string ItemtName { get; set; } = string.Empty;
        public decimal TotalValue { get; set; } = 0;
        public decimal UnitValue { get; set; } = 0;
        public decimal Quantity { get; set; } = 0;
        public decimal Budget { get; set; } = 0;
        public string Documentation { get; set; } = string.Empty;
        public DateTime AcquisitionDate { get; set; }
        public SuppliersVm Supplier { get; set; } = new ();
        public BusinessUnitsVm BusinessUnitsVm { get; set; } = new();
        public HistoricalRequirementVm HistoricalRequirement { get; set; } = new();
    }


    public class HistoricalRequirementVm
    {
        public Guid Id { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
        public DateTime ChangeDate {  get; set; }
    }

}
