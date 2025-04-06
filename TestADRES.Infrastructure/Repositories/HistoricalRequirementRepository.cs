using TestADRES.Application.Contracts.Persistence;
using TestADRES.Domain.Entities;
using TestADRES.Infrastructure.Persistence;

namespace TestADRES.Infrastructure.Repositories
{
    public class HistoricalRequirementRepository : RepositoryBase<HistoricalRequirement>, IHistoricalRequirementRepository
    {
        public HistoricalRequirementRepository(TestDbContext context) : base(context)
        {
        }
    }
}