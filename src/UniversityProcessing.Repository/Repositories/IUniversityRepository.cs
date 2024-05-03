using UniversityProcessing.Domain.Universities;

namespace UniversityProcessing.Repository.Repositories;

public interface IUniversityRepository
{
    Task<University[]> Get(
        int offset,
        int count,
        string orderBy,
        bool desc,
        CancellationToken cancellationToken = default);

    Task<University> Get(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Guid> Insert(University university, CancellationToken cancellationToken = default);

    Task<int> Update(University university, CancellationToken cancellationToken = default);

    Task<int> Delete(Guid id, CancellationToken cancellationToken = default);
}