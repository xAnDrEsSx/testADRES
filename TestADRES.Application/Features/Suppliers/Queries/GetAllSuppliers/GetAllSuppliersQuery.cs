using MediatR;

namespace TestADRES.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IRequest<List<SuppliersVm>>
    {
    }
}
