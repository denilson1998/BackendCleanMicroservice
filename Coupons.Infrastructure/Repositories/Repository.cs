using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using Coupons.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Coupons.Infrastructure.Repositories
{
    public class Repository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public Repository(ApplicationDbContext dbContext): base(dbContext)
        {
        }
    }
}