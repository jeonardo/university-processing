using UniversityProcessing.Infrastructure.Repositories;
using UniversityProcessing.Repository.Base;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.Infrastructure.Base;

public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    private FacultyRepository? _facultyRepository;
    private UniversityRepository? _universityRepository;

    public async Task CommitAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task RollbackAsync()
    {
        await dbContext.DisposeAsync();
    }

    public IFacultyRepository FacultyRepository()
    {
        return _facultyRepository ??= new FacultyRepository(dbContext);
    }

    public IUniversityRepository UniversityRepository()
    {
        return _universityRepository ??= new UniversityRepository(dbContext);
    }
}