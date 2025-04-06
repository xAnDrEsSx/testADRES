using AutoMapper;
using MediatR;
using TestADRES.Application.Contracts.Persistence;

namespace TestADRES.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, List<SuppliersVm>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllSuppliersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<SuppliersVm>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<SuppliersVm>>(await unitOfWork.SupplierRepository.GetAllAsync());
        }
    }
}
