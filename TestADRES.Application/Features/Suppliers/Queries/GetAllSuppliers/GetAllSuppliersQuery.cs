using MediatR;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IRequest<Response<List<SuppliersVm>>>
    {
    }
}
