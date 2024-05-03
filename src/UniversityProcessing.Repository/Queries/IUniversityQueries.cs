using UniversityProcessing.Abstractions.Http.Universities;

namespace UniversityProcessing.Repository.Queries;

public interface IUniversityQueries
{
    Task<UniversityDto[]> ListAsync(int offset, int count, string orderBy, bool desc, CancellationToken cancellationToken);
}