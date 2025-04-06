namespace TestADRES.Application.Features.Requirements.Queries.GetAllRequirement
{
    public class GetAllRequirementVm
    {
        public Guid RequerimentId { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public string ItemtName { get; set; } = string.Empty;
        public decimal TotalValue { get; set; } = 0;
        public DateTime AcquisitionDate { get; set; }
    }
}
