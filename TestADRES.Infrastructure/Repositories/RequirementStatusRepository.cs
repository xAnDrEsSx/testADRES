using TestADRES.Application.Contracts.Persistence;
using TestADRES.Domain.Entities;
using TestADRES.Infrastructure.Persistence;

namespace TestADRES.Infrastructure.Repositories
{
    public class RequirementStatusRepository : RepositoryBase<RequirementStatus>, IRequirementStatusRepository
    {
        public RequirementStatusRepository(TestDbContext context) : base(context)
        {
        }
    }
}
