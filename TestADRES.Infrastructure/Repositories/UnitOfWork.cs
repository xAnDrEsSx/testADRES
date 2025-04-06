using System.Collections;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Domain.Entities.Common;
using TestADRES.Infrastructure.Persistence;

namespace TestADRES.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private Hashtable _repositories;
        private readonly TestDbContext _context;
        private ISupplierRepository supplierRepository;

        public ISupplierRepository SupplierRepository => supplierRepository ??= new SupplierRepository(_context);



        public UnitOfWork(TestDbContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            // dispara configuracion de todas las transacciones
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            // elimine el context cuando la transaccion termine
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {

            if (_repositories == null)
            {
                _repositories = [];
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryIntance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryIntance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];

        }

    }

}
