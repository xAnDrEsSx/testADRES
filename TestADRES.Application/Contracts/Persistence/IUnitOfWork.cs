using TestADRES.Domain.Entities.Common;

namespace TestADRES.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
        ISupplierRepository SupplierRepository { get; }
        IBusinessUnitRepository BusinessUnitRepository { get; }
        IRequirementStatusRepository RequirementStatusRepository { get; }
        IRequirementRepository RequirementRepository { get; }
        IHistoricalRequirementRepository HistoricalRequirementRepository { get; }
    }

}
