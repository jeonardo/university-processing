using UniversityProcessing.Infrastructure.Base;
using UniversityProcessing.Infrastructure.Entities;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.Infrastructure.Repositories;

public sealed class FacultyRepository(ApplicationDbContext context) : EfRepository<FacultyEntity>(context),
    IFacultyRepository
{
}