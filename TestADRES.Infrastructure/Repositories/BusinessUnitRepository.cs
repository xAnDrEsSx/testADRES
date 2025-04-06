using TestADRES.Application.Contracts.Persistence;
using TestADRES.Domain.Entities;
using TestADRES.Infrastructure.Persistence;

namespace TestADRES.Infrastructure.Repositories
{
    public class BusinessUnitRepository : RepositoryBase<BusinessUnit>, IBusinessUnitRepository
    {
        public BusinessUnitRepository(TestDbContext context) : base(context)
        {
        }
    }
}
