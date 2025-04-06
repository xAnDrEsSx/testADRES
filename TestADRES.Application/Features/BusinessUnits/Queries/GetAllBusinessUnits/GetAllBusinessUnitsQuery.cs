using MediatR;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.BusinessUnits.Queries.GetAllBusinessUnits
{
    public class GetAllBusinessUnitsQuery : IRequest<Response<List<BusinessUnitsVm>>>
    {
    }
}
