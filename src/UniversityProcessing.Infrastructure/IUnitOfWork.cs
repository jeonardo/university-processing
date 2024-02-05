using UniversityProcessing.Infrastructure.Repositories;

namespace UniversityProcessing.Infrastructure
{
    public interface IUnitOfWork
    {
        IUniversityRepository UniversityRepository { get; }

        Task CommitAsync();

        Task RollbackAsync();
    }
}
