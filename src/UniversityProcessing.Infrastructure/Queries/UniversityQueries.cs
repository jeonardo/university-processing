using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Repository.Queries;

namespace UniversityProcessing.Infrastructure.Queries;

internal sealed class UniversityQueries(ApplicationDbContext db) : IUniversityQueries
{
    private readonly string[] _availableProperties = ["id", "name", "short_name"];

    public async Task<UniversityDto[]> ListAsync(int offset, int count, string orderBy, bool desc, CancellationToken cancellationToken)
    {
        var result = await db.Database
            .SqlQuery<UniversityDto>(
                $"""
                 select name, short_name
                 from universities
                 order by {ValidateOrderBy(orderBy)} {(desc ? "desc" : string.Empty)}
                 offset {offset}
                 limit {count}
                 """)
            .AsNoTracking()
            .ToArrayAsync(cancellationToken: cancellationToken);

        return result;
    }

    private string ValidateOrderBy(string orderBy)
    {
        var trimmedOrderBy = orderBy.Trim().ToLower();

        return _availableProperties.Contains(trimmedOrderBy)
            ? trimmedOrderBy
            : _availableProperties.First();
    }
}