using UniversityProcessing.API.Infrastructure.Entities;
using UniversityProcessing.API.Interfaces.Infrastructure;

namespace UniversityProcessing.API.Infrastructure.Repositories
{
    public class UniversityRepository(ApplicationDbContext dbContext) : AbstractRepository<UniversityEntity>(dbContext), IUniversityRepository
    {
    }
}
