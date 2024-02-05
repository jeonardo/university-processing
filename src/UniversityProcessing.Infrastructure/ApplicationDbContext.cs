
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;
using UniversityProcessing.Shared.Entities;

namespace UniversityProcessing.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

#pragma warning disable CS8618 // Required by Entity Framework

        public virtual DbSet<DepartmentEntity> Departments { get; set; }

        public virtual DbSet<DiplomaProcessingEntity> DiplomaProcessings { get; set; }

        public virtual DbSet<EmployeeEntity> Employees { get; set; }

        public virtual DbSet<FacultyEntity> Faculties { get; set; }

        public virtual DbSet<GraduateWorkEntity> GraduateWorks { get; set; }

        public virtual DbSet<SpecialtyEntity> Specialties { get; set; }

        public virtual DbSet<StatusEntity> Statuses { get; set; }

        public virtual DbSet<StudentEntity> Students { get; set; }

        public virtual DbSet<StudyGroupEntity> StudyGroups { get; set; }

        public virtual DbSet<UniversityEntity> Universities { get; set; }

        public virtual DbSet<UserProfileEntity> UserProfiles { get; set; }

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

        private static void ApplySnakeCaseNames(ModelBuilder modelBuilder)
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
