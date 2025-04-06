namespace TestADRES.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class SuppliersVm
    {
        public Guid Id { get; set; }
        public string LegalName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
