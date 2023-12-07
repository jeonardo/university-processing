
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Infrastructure.Entities;

namespace UniversityProcessing.API.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<FacultyEntity> Faculties { get; set; }
        public DbSet<SpecialtyEntity> Specialties { get; set; }
        public DbSet<StatusEntity> Statuses { get; set; }
        public DbSet<StudyGroupEntity> StudyGroups { get; set; }
        public DbSet<UniversityEntity> Universities { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
    }
}
