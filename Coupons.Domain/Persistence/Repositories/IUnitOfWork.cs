namespace Coupons.Domain.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

        Task CompleteAsync(CancellationToken cancellationToken);
    }
}