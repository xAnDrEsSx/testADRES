using TestADRES.Application.Contracts.Persistence;
using TestADRES.Domain.Entities;
using TestADRES.Infrastructure.Persistence;

namespace TestADRES.Infrastructure.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(TestDbContext context) : base(context)
        {
        }
    }

}
