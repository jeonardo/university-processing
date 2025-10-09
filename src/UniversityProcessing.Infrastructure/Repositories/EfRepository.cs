using Ardalis.SharedKernel;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Exceptions;

namespace UniversityProcessing.Infrastructure.Repositories;

public sealed class EfRepository<T>(ApplicationDbContext dbContext) : RepositoryBase<T>(dbContext), IEfRepository<T>
    where T : class, IAggregateRoot
{
    public DbSet<T> TypedDbContext => dbContext.Set<T>();

    public async Task<T> GetByIdRequiredAsync(long id, CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException($"{typeof(T).Name} with id = {id} not found");
    }

    public async Task AnyRequiredAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        var result = await AnyAsync(specification, cancellationToken);

        if (!result)
        {
            throw new NotFoundException($"{typeof(T).Name} not found");
        }
    }
}
