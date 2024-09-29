using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Context;

public interface IApplicationDbContext
{
    DbSet<Department> Departments { get; }
    DbSet<DiplomaPeriod> DiplomaPeriods { get; }
    DbSet<Faculty> Faculties { get; }
    DbSet<Diploma> Diplomas { get; }
    DbSet<Specialty> Specialties { get; }
    DbSet<Group> Groups { get; }
    DbSet<University> Universities { get; }
}
