using Ardalis.Specification.EntityFrameworkCore;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Infrastructure.Base;

public class EfRepository<T>(ApplicationDbContext context)
    : RepositoryBase<T>(context), IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
}