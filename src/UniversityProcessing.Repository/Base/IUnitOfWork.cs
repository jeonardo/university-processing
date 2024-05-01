namespace UniversityProcessing.Repository.Base;

public interface IUnitOfWork
{
    Task CommitAsync();

    Task RollbackAsync();
}