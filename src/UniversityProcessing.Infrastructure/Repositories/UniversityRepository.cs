using UniversityProcessing.Shared.Entities;

namespace UniversityProcessing.Infrastructure.Repositories
{
    public class UniversityRepository(ApplicationDbContext dbContext) : AbstractRepository<UniversityEntity>(dbContext), IUniversityRepository
    {
    }
}
