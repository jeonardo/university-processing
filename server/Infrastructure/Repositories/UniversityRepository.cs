using UniversityProcessing.API.Domain.Entities;

namespace UniversityProcessing.API.Infrastructure.Repositories
{
    public class UniversityRepository(ApplicationDbContext dbContext) : AbstractRepository<UniversityEntity>(dbContext), IUniversityRepository
    {
    }
}
