using Ardalis.SharedKernel;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace UniversityProcessing.Infrastructure.Interfaces.Repositories;

public interface IEfReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    DbSet<T> TypedDbContext { get; }

    Task<T> GetByIdRequiredAsync(long id, CancellationToken cancellationToken);

    Task AnyRequiredAsync(ISpecification<T> specification, CancellationToken cancellationToken);
}
