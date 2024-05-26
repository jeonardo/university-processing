using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.Infrastructure.Repositories;

// ReSharper disable once SuggestBaseTypeForParameterInConstructor
public sealed class EfRepository<T>(ApplicationDbContext dbContext) : RepositoryBase<T>(dbContext), IEfRepository<T>
    where T : class, IAggregateRoot
{
    public async Task<T> GetByIdRequiredAsync(Guid id, CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException($"{typeof(T).Name} with id = {id} not found");
    }
}