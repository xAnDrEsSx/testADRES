using AutoMapper;
using MediatR;
using TestADRES.Application.Common.TestADRES.Application.Common;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, Response<List<SuppliersVm>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllSuppliersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Response<List<SuppliersVm>>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var suppliers = await unitOfWork.SupplierRepository.GetAllAsync();

                if (suppliers == null || !suppliers.Any())
                {
                    return new Response<List<SuppliersVm>>([], GlobalMessages.NoSuppliersFound);
                }

                return new Response<List<SuppliersVm>>(mapper.Map<List<SuppliersVm>>(suppliers), GlobalMessages.SuppliersRetrievedSuccessfully);

            }
            catch (Exception ex)
            {
                return new Response<List<SuppliersVm>>(GlobalMessages.ErrorRetrievingSuppliers(ex.Message));
            }

        }
    }
}
