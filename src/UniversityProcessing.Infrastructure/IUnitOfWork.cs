using UniversityProcessing.Infrastructure.Repositories;

namespace UniversityProcessing.Infrastructure
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}
