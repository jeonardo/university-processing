using Ardalis.SharedKernel;
using Ardalis.Specification;

namespace UniversityProcessing.Infrastructure.Interfaces.Repositories;

public interface IEfReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    ApplicationDbContext DbContext { get; }

    Task<T> GetByIdRequiredAsync(Guid id, CancellationToken cancellationToken);

    Task AnyRequiredAsync(ISpecification<T> specification, CancellationToken cancellationToken);
}
