using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.Infrastructure;

#pragma warning disable CS8618 // Required by Entity Framework
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher? dispatcher = null)
    : IdentityDbContext<User, UserRole, Guid>(options)
{
    public DbSet<UniversityPosition> UniversityPositions { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DiplomaProcess> DiplomaPeriods { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Diploma> Diplomas { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Notification> Notifications { get; set; }

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
        base.OnModelCreating(modelBuilder);

        UseTphMappingStrategy(modelBuilder);

        ConfigureRelations(modelBuilder);

        ApplyIdentitySnakeCaseNames(modelBuilder);

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
    }

    // ReSharper disable once UnusedParameter.Local
    private static void AddInitData(ModelBuilder modelBuilder)
    {
    }

    private static void UseTphMappingStrategy(ModelBuilder modelBuilder)
    {
        // Configure TPH inheritance
        modelBuilder.Entity<User>()
            .HasDiscriminator(u => u.Role)
            .HasValue<Admin>(UserRoleType.Admin)
            .HasValue<Deanery>(UserRoleType.Deanery)
            .HasValue<Teacher>(UserRoleType.Teacher)
            .HasValue<Student>(UserRoleType.Student);
    }

    // ReSharper disable once UnusedParameter.Local
    private static void ConfigureRelations(ModelBuilder modelBuilder)
    {
    }
}
