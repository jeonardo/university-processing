using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;

namespace UniversityProcessing.Infrastructure.Base;

// ReSharper disable once SuggestBaseTypeForParameterInConstructor
public sealed class EfRepository<T>(ApplicationDbContext dbContext) : RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot;