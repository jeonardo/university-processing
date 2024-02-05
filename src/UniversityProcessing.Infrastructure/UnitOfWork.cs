using UniversityProcessing.Infrastructure.Repositories;

namespace UniversityProcessing.Infrastructure
{
    public class UnitOfWork(ApplicationDbContext dbContext, IUniversityRepository universityRepository) : IUnitOfWork
    {
        public IUniversityRepository UniversityRepository => universityRepository ??= new UniversityRepository(dbContext);

        public async Task CommitAsync()
            => await dbContext.SaveChangesAsync();

        public async Task RollbackAsync()
            => await dbContext.DisposeAsync();
    }
}