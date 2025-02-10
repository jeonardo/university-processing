using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;
using UniversityProcessing.Domain;
using UniversityProcessing.Repository.Context;

namespace UniversityProcessing.Infrastructure;

#pragma warning disable CS8618 // Required by Entity Framework
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher? dispatcher = null)
    : IdentityDbContext<User, UserRole, Guid>(options), IApplicationDbContext
{
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<DiplomaProcess> DiplomaPeriods => Set<DiplomaProcess>();
    public DbSet<Faculty> Faculties => Set<Faculty>();
    public DbSet<Diploma> Diplomas => Set<Diploma>();
    public DbSet<Specialty> Specialties => Set<Specialty>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Notification> Notifications => Set<Notification>();

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

    private static void AddInitData(ModelBuilder modelBuilder)
    {
        //Can be filled by the real migration
    }

    private static void UseTphMappingStrategy(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .UseTphMappingStrategy(); //TODO add details
    }

    private static void ConfigureRelations(ModelBuilder modelBuilder)
    {
        //TODO add manual
        // modelBuilder
        //     .Entity<Department>()
        //     .HasOne(b => b.Faculty)
        //     .WithMany(a => a.Departments)
        //     .HasForeignKey(b => b.FacultyId)
        //     .OnDelete(DeleteBehavior.NoAction);
    }
}
