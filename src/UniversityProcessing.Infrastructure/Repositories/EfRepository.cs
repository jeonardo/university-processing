using Ardalis.Specification.EntityFrameworkCore;

namespace UniversityProcessing.Infrastructure.Repositories
{
    public class EfRepository<T>(ApplicationDbContext context)
        : RepositoryBase<T>(context), IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {

    }
}
