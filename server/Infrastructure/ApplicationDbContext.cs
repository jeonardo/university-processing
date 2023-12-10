
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;
using UniversityProcessing.API.Infrastructure.Entities;

namespace UniversityProcessing.API.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().UseTphMappingStrategy();  // TPH

            base.OnModelCreating(modelBuilder);

            // Move Identity to "myschema" Schema:
            modelBuilder.Entity<UserEntity>().ToTable("users", "public");
            modelBuilder.Entity<UserRoleEntity>().ToTable("roles", "public");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens", "public");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_roles", "public");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claims", "public");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims", "public");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins", "public");

            // Apply Snake Case Names for Properties:
            ApplySnakeCaseNames(modelBuilder);
        }

        public required virtual DbSet<DepartmentEntity> Departments { get; set; }

        public required virtual DbSet<DiplomaProcessingEntity> DiplomaProcessings { get; set; }

        public required virtual DbSet<EmployeeEntity> Employees { get; set; }

        public required virtual DbSet<FacultyEntity> Faculties { get; set; }

        public required virtual DbSet<GraduateWorkEntity> GraduateWorks { get; set; }

        public required virtual DbSet<SpecialtyEntity> Specialties { get; set; }

        public required virtual DbSet<StatusEntity> Statuses { get; set; }

        public required virtual DbSet<StudentEntity> Students { get; set; }

        public required virtual DbSet<StudyGroupEntity> StudyGroups { get; set; }

        public required virtual DbSet<UniversityEntity> Universities { get; set; }

        public required virtual DbSet<UserProfileEntity> UserProfiles { get; set; }

        private void ApplySnakeCaseNames(ModelBuilder modelBuilder)
        {
            var mapper = new NpgsqlSnakeCaseNameTranslator();

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    var npgsqlColumnName = mapper.TranslateMemberName(property.GetColumnName());

                    property.SetColumnName(npgsqlColumnName);
                }
            }
        }
    }
}
