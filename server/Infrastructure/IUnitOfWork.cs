using UniversityProcessing.API.Infrastructure.Repositories;

namespace UniversityProcessing.API.Infrastructure
{
    public interface IUnitOfWork
    {
        IUniversityRepository UniversityRepository { get; }

        Task CommitAsync();

        Task RollbackAsync();
    }
}
