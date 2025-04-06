using TestADRES.Application.Contracts.Persistence;
using TestADRES.Domain.Entities;
using TestADRES.Infrastructure.Persistence;

namespace TestADRES.Infrastructure.Repositories
{
    public class RequirementRepository : RepositoryBase<Requirement>, IRequirementRepository
    {
        public RequirementRepository(TestDbContext context) : base(context)
        {
        }
    }
}