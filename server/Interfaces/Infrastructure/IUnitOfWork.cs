namespace UniversityProcessing.API.Interfaces.Infrastructure
{
    public interface IUnitOfWork
    {
        IUniversityRepository UniversityRepository { get; }

        Task CommitAsync();

        Task RollbackAsync();
    }
}
