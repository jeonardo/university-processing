using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.Faculties.Get.Contracts;

namespace UniversityProcessing.DomainServices.Features.Faculties.Get;

internal sealed class FacultyGetQueryHandler(IReadRepository<Faculty> repository) : IRequestHandler<FacultyGetQueryRequest, FacultyGetQueryResponse>
{
    public async Task<FacultyGetQueryResponse> Handle(FacultyGetQueryRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Faculty)} with id = {request.Id} not found");

        return new FacultyGetQueryResponse(FacultyConverter.ToDto(record));
    }
}