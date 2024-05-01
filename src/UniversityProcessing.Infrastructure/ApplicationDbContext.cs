using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Entities;

namespace UniversityProcessing.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<User, UserRole, Guid>(options)
{
#pragma warning disable CS8618 // Required by Entity Framework

    public DbSet<EmployeeEntity> Employees { get; set; }

    public DbSet<StudentEntity> Students { get; set; }

    public DbSet<DepartmentEntity> Departments { get; set; }

    public DbSet<DiplomaProcessingEntity> DiplomaProcessings { get; set; }

    public DbSet<FacultyEntity> Faculties { get; set; }

    public DbSet<GraduateWorkEntity> GraduateWorks { get; set; }

    public DbSet<SpecialtyEntity> Specialties { get; set; }

    public DbSet<StatusEntity> Statuses { get; set; }

    public DbSet<StudyGroupEntity> StudyGroups { get; set; }

    public DbSet<UniversityEntity> Universities { get; set; }

    public DbSet<UserProfileEntity> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TPH
        modelBuilder.Entity<User>().UseTphMappingStrategy();

        base.OnModelCreating(modelBuilder);

        // Move Identity to "myschema" Schema:
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<UserRole>().ToTable("roles");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_roles");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claims");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");

        // Apply Snake Case Names for Properties:
        ApplySnakeCaseNames(modelBuilder);

        AddInitData(modelBuilder);
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

    private static void AddInitData(ModelBuilder modelBuilder)
    {
        //Can be filled by the real migration
    }
}