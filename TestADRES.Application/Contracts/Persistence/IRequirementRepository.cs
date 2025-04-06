using TestADRES.Domain.Entities;

namespace TestADRES.Application.Contracts.Persistence
{
    public interface IRequirementRepository : IAsyncRepository<Requirement>
    {
    }
}
