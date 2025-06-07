namespace UniversityProcessing.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Faculty> Faculties { get; }

    DbSet<DiplomaProject> DiplomaProjects { get; }

    // Другие DbSet...

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
