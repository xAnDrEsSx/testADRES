namespace TestADRES.Application.Features.BusinessUnits.Queries.GetAllBusinessUnits
{
    public class BusinessUnitsVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
