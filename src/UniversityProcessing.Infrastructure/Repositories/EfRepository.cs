using Ardalis.SharedKernel;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.Infrastructure.Repositories;

public sealed class EfRepository<T>(DbContext dbContext) : RepositoryBase<T>(dbContext), IEfRepository<T>
    where T : class, IAggregateRoot
{
    public async Task<T> GetByIdRequiredAsync(Guid id, CancellationToken cancellationToken)
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
