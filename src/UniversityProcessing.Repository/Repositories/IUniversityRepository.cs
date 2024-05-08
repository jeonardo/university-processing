using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Repositories;

public interface IUniversityRepository
{
    Task<University[]> Get(
        int offset,
        int count,
        string orderBy,
        bool desc,
        CancellationToken cancellationToken);

    Task<University> Get(
        Guid id,
        CancellationToken cancellationToken);

    Task<Guid> Insert(University university, CancellationToken cancellationToken);

    Task<int> Update(University university, CancellationToken cancellationToken);

    Task<int> Delete(Guid id, CancellationToken cancellationToken);
}