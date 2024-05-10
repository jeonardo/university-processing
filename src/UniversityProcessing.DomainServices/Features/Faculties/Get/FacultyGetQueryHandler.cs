using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.Faculties.Get.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Faculties.Get;

internal sealed class FacultyGetQueryHandler(IEfReadRepository<Faculty> repository) : IRequestHandler<FacultyGetQueryRequest, FacultyGetQueryResponse>
{
    public async Task<FacultyGetQueryResponse> Handle(FacultyGetQueryRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        return new FacultyGetQueryResponse(FacultyConverter.ToDto(record));
    }
}