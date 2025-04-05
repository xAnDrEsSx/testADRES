using TestADRES.Application.Contracts.Persistence;
using TestADRES.Domain.Entities.Common;

namespace TestADRES.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        //private Hashtable _repositories;
        //private readonly TestDbContext _context;
        //private IEmployeeRepository _employeeRepository;
        //private IPermissionRepository _permissionRepository;
        //private IPermissionTypeRepository _permissionTypeRepository;


        //public IEmployeeRepository EmployeeRepository => _employeeRepository ??= new EmployeeRepository(_context);


        //public UnitOfWork(TestDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<int> Complete()
        //{
        //    // dispara configuracion de todas las transacciones
        //    return await _context.SaveChangesAsync();
        //}

        //public void Dispose()
        //{
        //    // elimine el context cuando la transaccion termine
        //    _context.Dispose();
        //}

        //public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        //{

        //    if (_repositories == null)
        //    {
        //        _repositories = new Hashtable();
        //    }

        //    var type = typeof(TEntity).Name;

        //    if (!_repositories.ContainsKey(type))
        //    {
        //        var repositoryType = typeof(RepositoryBase<>);
        //        var repositoryIntance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
        //        _repositories.Add(type, repositoryIntance);
        //    }

        //    return (IAsyncRepository<TEntity>)_repositories[type];

        //}
        public Task<int> Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            throw new NotImplementedException();
        }
    }

}
