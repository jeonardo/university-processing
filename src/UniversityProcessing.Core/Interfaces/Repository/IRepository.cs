namespace UniversityProcessing.Core.Interfaces.Repository;

public interface IRepository<T> where T : EntityBase

{
    Task<T?> GetByIdAsync(Guid id);

    Task<IReadOnlyList<T>> GetAllAsync();

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
