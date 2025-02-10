using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;

// ReSharper disable ReturnTypeCanBeEnumerable.Global

namespace UniversityProcessing.Repository.Context;

public interface IApplicationDbContext
{
    DbSet<Department> Departments { get; }
    DbSet<DiplomaProcess> DiplomaPeriods { get; }
    DbSet<Faculty> Faculties { get; }
    DbSet<Diploma> Diplomas { get; }
    DbSet<Specialty> Specialties { get; }
    DbSet<Group> Groups { get; }
    DbSet<Notification> Notifications { get; }
}
