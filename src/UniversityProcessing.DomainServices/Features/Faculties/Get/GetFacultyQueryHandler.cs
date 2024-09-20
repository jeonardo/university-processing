using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Faculties.Get;

internal sealed class GetFacultyQueryHandler(IEfReadRepository<Faculty> repository) : IRequestHandler<GetFacultyQueryRequest, GetFacultyQueryResponse>
{
    public async Task<GetFacultyQueryResponse> Handle(GetFacultyQueryRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        return new GetFacultyQueryResponse(FacultyConverter.ToDto(record));
    }
}
