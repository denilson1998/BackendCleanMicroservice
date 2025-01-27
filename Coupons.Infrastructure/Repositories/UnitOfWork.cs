using Coupons.Domain.Persistence.Repositories;

namespace Coupons.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task CompleteAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}