using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;

// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace UniversityProcessing.Infrastructure;

#pragma warning disable CS8618 // Required by Entity Framework
public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher? dispatcher = null)
    : IdentityDbContext<User, UserRole, Guid>(options)
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Deanery> Deaneries { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<UniversityPosition> UniversityPositions { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DiplomaProcess> DiplomaProcesses { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Diploma> Diplomas { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<ProjectTitle> ProjectTitles { get; set; }
    public DbSet<Committee> Committees { get; set; }
    public DbSet<Period> Periods { get; set; }
    public DbSet<DefenseSession> DefenseSessions { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (dispatcher == null)
        {
            return result;
        }

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync()
            .GetAwaiter()
            .GetResult();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); //Check table naming

        ConfigureRelations(modelBuilder);

        ApplySnakeCaseNames(modelBuilder);

        AddInitData(modelBuilder);
    }

    private static void ApplyIdentitySnakeCaseNames(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<UserRole>().ToTable("roles");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_roles");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claims");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
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

        ApplyIdentitySnakeCaseNames(modelBuilder);
    }

    // ReSharper disable once UnusedParameter.Local
    private static void AddInitData(ModelBuilder modelBuilder)
    {
    }

    // ReSharper disable once UnusedParameter.Local
    private static void ConfigureRelations(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .UseTptMappingStrategy();

        modelBuilder.Entity<Student>(
            x =>
            {
                x.HasOne(s => s.Diploma)
                    .WithOne(d => d.Student)
                    .HasForeignKey<Student>(c => c.DiplomaId)
                    .OnDelete(DeleteBehavior.Cascade);

                x.HasOne(s => s.Group)
                    .WithMany(g => g.Students)
                    .HasForeignKey(s => s.GroupId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        modelBuilder.Entity<Teacher>(
            x =>
            {
                x.HasOne(t => t.UniversityPosition)
                    .WithMany(up => up.Teachers)
                    .HasForeignKey(t => t.UniversityPositionId)
                    .OnDelete(DeleteBehavior.Cascade);

                x.HasOne(t => t.Department)
                    .WithMany(d => d.Teachers)
                    .HasForeignKey(t => t.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade);

                x.HasMany(t => t.Diplomas)
                    .WithOne(d => d.Supervisor)
                    .HasForeignKey(d => d.SupervisorId)
                    .OnDelete(DeleteBehavior.Cascade);

                x.HasMany(t => t.DiplomaProcesses)
                    .WithMany(dp => dp.Teachers)
                    .UsingEntity<Dictionary<string, object>>(
                        "TeacherDiplomaProcess",
                        j => j.HasOne<DiplomaProcess>()
                            .WithMany()
                            .HasForeignKey("diploma_process_id")
                            .OnDelete(DeleteBehavior.Cascade),
                        j => j.HasOne<Teacher>()
                            .WithMany()
                            .HasForeignKey("teacher_id")
                            .OnDelete(DeleteBehavior.Cascade),
                        j =>
                        {
                            j.HasKey("teacher_id", "diploma_process_id");
                            j.ToTable("teacher_diploma_processes");
                        });

                x.HasMany(t => t.Committees)
                    .WithMany(c => c.Teachers)
                    .UsingEntity<Dictionary<string, object>>(
                        "TeacherCommittee",
                        j => j.HasOne<Committee>()
                            .WithMany()
                            .HasForeignKey("committee_id")
                            .OnDelete(DeleteBehavior.Cascade),
                        j => j.HasOne<Teacher>()
                            .WithMany()
                            .HasForeignKey("teacher_id")
                            .OnDelete(DeleteBehavior.Cascade),
                        j =>
                        {
                            j.HasKey("teacher_id", "committee_id");
                            j.ToTable("teacher_committees");
                        });
            });

        modelBuilder.Entity<Deanery>(
            x =>
            {
                x.HasOne(t => t.UniversityPosition)
                    .WithMany(up => up.Deaneries)
                    .HasForeignKey(t => t.UniversityPositionId)
                    .OnDelete(DeleteBehavior.Cascade);

                x.HasOne(d => d.Faculty)
                    .WithMany(f => f.Deaneries)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
    }
}
