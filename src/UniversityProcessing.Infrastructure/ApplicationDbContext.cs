using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Infrastructure;

#pragma warning disable CS8618 // Required by Entity Framework
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher? dispatcher = null)
    : IdentityDbContext<User, UserRole, Guid>(options)
{
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<DiplomaPeriod> DiplomaPeriods => Set<DiplomaPeriod>();
    public DbSet<Faculty> Faculties => Set<Faculty>();
    public DbSet<Diploma> Diplomas => Set<Diploma>();
    public DbSet<Specialty> Specialties => Set<Specialty>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<University> Universities => Set<University>();

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
        return SaveChangesAsync().GetAwaiter().GetResult();
    }

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