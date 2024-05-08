using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.Specialties.Get.Contracts;

namespace UniversityProcessing.DomainServices.Features.Specialties.Get;

internal sealed class SpecialtyGetQueryHandler(IReadRepository<Specialty> repository)
    : IRequestHandler<SpecialtyGetQueryRequest, SpecialtyGetQueryResponse>
{
    public async Task<SpecialtyGetQueryResponse> Handle(
        SpecialtyGetQueryRequest request,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Specialty)} with id = {request.Id} not found");

        return new SpecialtyGetQueryResponse(SpecialtyConverter.ToDto(record));
    }
}