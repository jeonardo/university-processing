using Ardalis.SharedKernel;
using Ardalis.Specification;

namespace UniversityProcessing.Repository.Repositories;

public interface IEfReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    Task<T> GetByIdRequiredAsync(Guid id, CancellationToken cancellationToken);

    Task AnyRequiredAsync(ISpecification<T> specification, CancellationToken cancellationToken);
}
